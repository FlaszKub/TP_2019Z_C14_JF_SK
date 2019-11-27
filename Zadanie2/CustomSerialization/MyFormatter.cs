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
        public override ISurrogateSelector SurrogateSelector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override SerializationBinder Binder { get; set; }
        public override StreamingContext Context { get; set; }
        private StringBuilder builder;
        private CultureInfo culture = CultureInfo.InvariantCulture;


        public MyFormatter() : base()
        {
            builder = new StringBuilder();
            Binder = new MySerializationBinder();

        }
        private Dictionary<string, object> deserializedObjects = new Dictionary<string, object>();
        private Dictionary<string, SerializationInfo> deserializedInfo = new Dictionary<string, SerializationInfo>();
        public override object Deserialize(Stream serializationStream)
        {
            deserializedObjects = new Dictionary<string, object>();
            deserializedInfo = new Dictionary<string, SerializationInfo>();
            Context = new StreamingContext();
            object graph;
            object obj;
            string line;
            string[] dataLine = new string[3];
            string[] keyValue = new string[2];
            string[] reference = new string[2];
            SerializationInfo info;
            Type type;
            using (StreamReader reader = new StreamReader(serializationStream))
            {
                line = reader.ReadLine();
                dataLine = line.Split(';');
                type = Binder.BindToType(dataLine[2], dataLine[1]);
                info = new SerializationInfo(type.GetType(), new FormatterConverter());
                graph = FormatterServices.GetSafeUninitializedObject(type);
                deserializedObjects.Add(dataLine[0], graph);
                deserializedInfo.Add(dataLine[0], info);
                while ((line = reader.ReadLine()) != "##")
                {
                    dataLine = line.Split(';');
                    type = Type.GetType(dataLine[1]);
                    if (Regex.IsMatch(dataLine[0], @"^href[$]\d*"))
                    {
                        type = Binder.BindToType(dataLine[2], dataLine[1]);
                        info = new SerializationInfo(type, new FormatterConverter());
                        deserializedInfo.Add(dataLine[0], info);
                        if (!deserializedObjects.ContainsKey(dataLine[0]))
                        {
                            obj = FormatterServices.GetSafeUninitializedObject(type);
                            deserializedObjects.Add(dataLine[0], obj);
                        }
                    }
                    else
                    {
                        keyValue = dataLine[0].Split('=');
                        if (Regex.IsMatch(keyValue[1], @"^href[$]\d*"))
                        {
                            type = Binder.BindToType(dataLine[2], dataLine[1]);
                            if (!deserializedObjects.ContainsKey(keyValue[1]))
                            {
                                obj = FormatterServices.GetSafeUninitializedObject(type);
                                deserializedObjects.Add(keyValue[1], obj);
                            }
                            else
                            {
                                obj = deserializedObjects[keyValue[1]];
                            }
                            info.AddValue(keyValue[0], obj, type);
                        }
                        else
                        {
                            if (type == typeof(DateTime))
                            {
                                info.AddValue(keyValue[0], DateTime.Parse(keyValue[1], culture), type);
                            }
                            else
                            {
                                info.AddValue(keyValue[0], keyValue[1], type);
                            }
                        }

                    }
                }

            }
            Type objectType;
            Type[] argumentTypes = new Type[2];
            argumentTypes[0] = typeof(SerializationInfo);
            argumentTypes[1] = typeof(StreamingContext);
            foreach (string key in deserializedInfo.Keys)
            {
                objectType = deserializedObjects[key].GetType();
                ConstructorInfo constructor = objectType.GetConstructor(argumentTypes);
                constructor.Invoke(deserializedObjects[key], new object[] { deserializedInfo[key], Context });

            }
            return graph;
        }

        public override void Serialize(Stream serializationStream, object graph)
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

        protected override void WriteDateTime(DateTime val, string name)
        {
            builder.Append(name + '=' + val.ToString(culture) + ';' + typeof(DateTime).ToString() + "\n");
        }

        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            Binder.BindToName(obj.GetType(), out string assemblyName, out string typeName);
            if (memberType.ToString() == "System.String")
                builder.Append(name + '=' + (string)obj + ';' + typeName + "\n");
            else
            {
                long id = Schedule(obj);
                builder.Append(name + '=' + "href$" + id.ToString(culture) + ";" + typeName + ';' + assemblyName + "\n");
            }

        }
        protected override void WriteSingle(float val, string name)
        {
            builder.Append(name + '=' + val.ToString(culture) + ';' + typeof(float).ToString() + "\n");
        }
    }
}
