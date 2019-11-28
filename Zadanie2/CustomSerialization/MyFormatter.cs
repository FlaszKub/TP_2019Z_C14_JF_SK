using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

namespace CustomSerialization
{
    public class MyFormatter : FormatterAdapter
    {
        public override SerializationBinder Binder { get; set; }
        public override StreamingContext Context { get; set; }
        private StringBuilder builder;
        private readonly CultureInfo culture = CultureInfo.InvariantCulture;
        private Dictionary<string, object> deserializedObjects;
        private Dictionary<string, SerializationInfo> deserializedInfo;

        public MyFormatter() : base()
        {
            builder = new StringBuilder();
            Binder = new MySerializationBinder();

        }
        
        #region Serialize

        public override void Serialize(Stream serializationStream, object graph)
        {
            if (graph is ISerializable)
            {
                Schedule(graph);
                object obj;
                while ((obj = GetNext(out long objID)) != null)
                {
                    Binder.BindToName(obj.GetType(), out string assemblyName, out string typeName);
                    builder.Append("href$" + objID.ToString(culture) + ";" + typeName + ';' + assemblyName + "\n");
                    ISerializable _data = (ISerializable)obj;
                    SerializationInfo _info = new SerializationInfo(obj.GetType(), new FormatterConverter());
                    StreamingContext _context = new StreamingContext(StreamingContextStates.File);
                    _data.GetObjectData(_info, _context);
                    foreach (SerializationEntry _item in _info)
                        this.WriteMember(_item.Name, _item.Value);


                }
                builder.Append("##");
                using (StreamWriter output = new StreamWriter(serializationStream))
                {
                    output.WriteLine(builder.ToString());
                }
            }
            else
            {
                throw new SerializationException("Graph must be ISerializable");
            }
        }

        protected override void WriteDateTime(DateTime val, string name)
        {
            builder.Append(name + '=' + val.ToString(culture) + ';' + typeof(DateTime).FullName + "\n");
        }

        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {

            if (obj == null)
            {
                builder.Append(name + '=' + "null" + ';' + null + "\n");

            }
            else
            {
                Binder.BindToName(obj.GetType(), out string assemblyName, out string typeName);
                if (typeName == "System.String")
                {
                    builder.Append(name + '=' + (string)obj + ';' + typeName + "\n");
                }
                else
                {
                    long id = Schedule(obj);
                    builder.Append(name + '=' + "href$" + id.ToString(culture) + ";" + typeName + ';' + assemblyName + "\n");
                }
            }

        }
        protected override void WriteSingle(float val, string name)
        {
            builder.Append(name + '=' + val.ToString(culture) + ';' + typeof(float).FullName + "\n");
        }

        #endregion

        #region Deserialize

        public override object Deserialize(Stream serializationStream)
        {
            deserializedObjects = new Dictionary<string, object>();
            deserializedInfo = new Dictionary<string, SerializationInfo>();
            Context = new StreamingContext();
            object graph;
            object obj;
            string line;
            Type type;
            using (StreamReader reader = new StreamReader(serializationStream))
            {
                line = reader.ReadLine();
                string[] dataLine = line.Split(';');
                type = Binder.BindToType(dataLine[2], dataLine[1]);
                SerializationInfo _info = new SerializationInfo(type.GetType(), new FormatterConverter());
                graph = FormatterServices.GetSafeUninitializedObject(type);
                deserializedObjects.Add(dataLine[0], graph);
                deserializedInfo.Add(dataLine[0], _info);
                while ((line = reader.ReadLine()) != "##")
                {
                    dataLine = line.Split(';');
                    if (Regex.IsMatch(dataLine[0], @"^href[$]\d*"))
                    {
                        type = Binder.BindToType(dataLine[2], dataLine[1]);
                        _info = new SerializationInfo(type, new FormatterConverter());
                        deserializedInfo.Add(dataLine[0], _info);
                        if (!deserializedObjects.ContainsKey(dataLine[0]))
                        {
                            obj = FormatterServices.GetSafeUninitializedObject(type);
                            deserializedObjects.Add(dataLine[0], obj);
                        }
                    }
                    else
                    {
                        AddToSerializationInfo(dataLine, _info);
                    }
                }

            }
            InitializeObjects();
            return graph;
        }

        private void ParseAndAddToSerializationInfo(Type type, string name, string data, SerializationInfo _info) {
            if (type == null)
            {
                _info.AddValue(name, null);
            }
            else
            {
                switch (type.ToString())
                {
                    case "System.String":
                        _info.AddValue(name, data);
                        break;

                    case "System.Single":
                        _info.AddValue(name, float.Parse(data, culture));
                        break;

                    case "System.DateTime":
                        _info.AddValue(name, DateTime.Parse(data, culture));
                        break;
                }
            }
        }

        private void AddToSerializationInfo(string[] dataLine, SerializationInfo _info)
        {
            string[] keyValue = dataLine[0].Split('=');
            object obj;
            
            if (Regex.IsMatch(keyValue[1], @"^href[$]\d*"))
            {
                Type type = Binder.BindToType(dataLine[2], dataLine[1]);
                if (!deserializedObjects.ContainsKey(keyValue[1]))
                {
                    obj = FormatterServices.GetSafeUninitializedObject(type);
                    deserializedObjects.Add(keyValue[1], obj);
                }
                else
                {
                    obj = deserializedObjects[keyValue[1]];
                }
                _info.AddValue(keyValue[0], obj, type);
            }
            else
            {
                Type type = Type.GetType(dataLine[1]);
                ParseAndAddToSerializationInfo(type, keyValue[0], keyValue[1], _info);
            }
        }

        private void InitializeObjects() {
            Type objectType;
            Type[] argumentTypes = new Type[] { typeof(SerializationInfo), typeof(StreamingContext) };
            foreach (KeyValuePair<string, object> entry in deserializedObjects)
            {
                objectType = entry.Value.GetType();
                ConstructorInfo constructor = objectType.GetConstructor(argumentTypes);
                constructor.Invoke(entry.Value, new object[] { deserializedInfo[entry.Key], Context });

            }
        }
        #endregion
    }
}
