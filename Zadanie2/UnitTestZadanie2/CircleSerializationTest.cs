using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestZadanie2
{
    [TestClass]
    public class CircleSerializationTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ClassA a = new ClassA("Dupa", 5);
            ClassB b = new ClassB("Ala");
            a.ClassB = b;
            b.ClassA = a;
            System.Console.WriteLine(a.Serialize(new System.Runtime.Serialization.ObjectIDGenerator()));
            CircleSerializer serializer = new CircleSerializer();
            MemoryStream ms = new MemoryStream();
            serializer.Serialize(a, ms);
            ms.Position = 0;
            ClassA deserlizedA = (ClassA)serializer.Deserialize(ms);
            System.Console.WriteLine(deserlizedA.Serialize(new System.Runtime.Serialization.ObjectIDGenerator()));
            Assert.AreEqual<string>(a.Description, deserlizedA.Description);
        }

        [TestMethod]
        public void TestMethod2()
        {
            ClassA a = new ClassA("A", 1);
            ClassB b = new ClassB("B");
            ClassA c = new ClassA("C", 2);
            ClassB d = new ClassB("D");
            a.ClassB = b;
            b.ClassA = c;
            c.ClassB = d;
            d.ClassA = a;
            System.Console.WriteLine(a.Serialize(new System.Runtime.Serialization.ObjectIDGenerator()));
            Assert.AreEqual(a.ClassB.ClassA.ClassB.ClassA, a);
            CircleSerializer serializer = new CircleSerializer();
            MemoryStream ms = new MemoryStream();
            serializer.Serialize(a, ms);
            ms.Position = 0;
            ClassA deserlizedA = (ClassA)serializer.Deserialize(ms);
            System.Console.WriteLine(deserlizedA.Serialize(new System.Runtime.Serialization.ObjectIDGenerator()));
            //Assert.AreEqual(deserlizedA.ClassB.ClassA.ClassB.ClassA, deserlizedA);
        }
    }
}
