using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    [Serializable]
    public class ClassC : ISerializable
    {
        public ClassA ClassA { get; set; }
        public ClassB ClassB { get; set; }
        public DateTime Date { get; set;}
        public string Name { get; set; }
        public float Num { get; set; }
        public ClassC(string name, float num, DateTime date)
        {
            Name = name;
            Num = num;
            Date = date;
        }

        public ClassC(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("name");
            Date = info.GetDateTime("date");
            Num = info.GetSingle("num");
            ClassA = (ClassA) info.GetValue("classA", typeof(ClassA));
            ClassB = (ClassB) info.GetValue("classB", typeof(ClassB));


        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", Name);
            info.AddValue("num", Num);
            info.AddValue("date", Date);
            info.AddValue("classA", ClassA);
            info.AddValue("classB", ClassB);
        }
    }
}
