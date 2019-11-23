using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Zadanie2
{
    [Serializable]
    public class ClassA : ISerializable
    {
        public ClassB ClassB { get; set; }
        public ClassC ClassC { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public float Num { get; set; }
        public ClassA(string name, float num, DateTime date)
        {
            Name = name;
            Num = num;
            Date = date;
        }

        public ClassA(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("name");
            Date = info.GetDateTime("date");
            Num = (float)info.GetDouble("num");
            ClassB = (ClassB)info.GetValue("classB", typeof(ClassB));
            ClassC = (ClassC)info.GetValue("classC", typeof(ClassC));


        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", Name);
            info.AddValue("num", Num);
            info.AddValue("date", Date);
            info.AddValue("classB", ClassB);
            info.AddValue("classC", ClassC);
        }
    }
}