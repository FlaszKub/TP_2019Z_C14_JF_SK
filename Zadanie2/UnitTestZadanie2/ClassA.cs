using System.Collections.Generic;
using System.Runtime.Serialization;
using Zadanie2;

namespace UnitTestZadanie2
{
    class ClassA : ICSerializable
    {
        public ClassB ClassB { get; set; }
        public string Description { get; set; }


        public ClassA()
        {
            Description = "Opis 1";
        }

        public string Serialize(ObjectIDGenerator gen, char separator)
        {
            string result = this.GetType().FullName + separator
                    + gen.GetId(this, out bool classATime) + separator
                    + Description + separator
                    + gen.GetId(ClassB,out bool classBTime);
            if (classBTime)
            {
                result += '>' + ClassB.Serialize(gen, separator);
            }
            return result;
        }

        public void Deserialize(string[] data, Dictionary<int, object> refObjectsDict)
        {
            this.ClassB = (ClassB)refObjectsDict[int.Parse(data[3])];
        }


    }
}
