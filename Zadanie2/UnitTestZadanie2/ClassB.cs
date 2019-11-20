
using System.Collections.Generic;
using System.Runtime.Serialization;
using Zadanie2;

namespace UnitTestZadanie2
{
    class ClassB : ICSerializable
    {
        public ClassA ClassA { get; set; }
        public string Description { get; set; }



        public ClassB()
        {
            this.Description = "des 2";
        }

        public string Serialize(ObjectIDGenerator gen, char separator)
        {
            separator = ',';
            string result = this.GetType().FullName + separator
                    + gen.GetId(this, out bool classBTime) + separator
                    + Description + separator
                    + gen.GetId(ClassA, out bool classATime);
            if (classATime)
            {
                    result += '>' + ClassA.Serialize(gen, separator);
            }
            return result;
        }

        public void Deserialize(string[] data, Dictionary<int, object> refObjectsDict)
        {
            this.ClassA = (ClassA)refObjectsDict[int.Parse(data[3])];
        }


    }
}
