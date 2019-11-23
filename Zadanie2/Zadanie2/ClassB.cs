using System;
using System.Runtime.Serialization;

namespace Zadanie2
{
    [Serializable]
    public class ClassB : ISerializable
    {
        public ClassA ClassA { get; set; }
        public ClassC ClassC { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public float Num { get; set; }
        public ClassB(string name, float num, DateTime date)
        {
            Name = name;
            Num = num;
            Date = date;
        }

        public ClassB(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("name");
            Date = info.GetDateTime("date");
            Num = (float)info.GetDouble("num");
            ClassA = (ClassA)info.GetValue("classA", typeof(ClassA));
            ClassC = (ClassC)info.GetValue("classC", typeof(ClassC));


        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", Name);
            info.AddValue("num", Num);
            info.AddValue("date", Date);
            info.AddValue("classA", ClassA);
            info.AddValue("classC", ClassC);
        }
    }
}
