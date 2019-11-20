using System;
using System.IO;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestZadanie2
{
    [TestClass]
    public class RecursiveSerializationTest
    {
        [TestMethod]
        public void SingleRecursiveTest()
        {
            ClassA a = new ClassA();
            ClassB b = new ClassB();
            a.ClassB = b;
            b.ClassA = a;
            RecursiveSerializer serializer = new RecursiveSerializer();
            MemoryStream ms = new MemoryStream();
            serializer.Serialize(a, ms);
            ms.Position = 0;
            ClassA deserlizedA = (ClassA)serializer.Deserialize(ms);
            Assert.AreEqual<string>(a.Description, deserlizedA.Description);
            Assert.AreEqual<string>(a.Serialize(new ObjectIDGenerator(), ','), deserlizedA.Serialize(new ObjectIDGenerator(), ','));
        }

        [TestMethod]
        public void RecursiveInMoreThanTowObjectsTest()
        {

            ClassA a = new ClassA();
            ClassB b = new ClassB();
            ClassA c = new ClassA();
            ClassB d = new ClassB();
            a.ClassB = b;
            b.ClassA = c;
            c.ClassB = d;
            d.ClassA = a;
            Assert.AreEqual(a.ClassB.ClassA.ClassB.ClassA, a);
            RecursiveSerializer serializer = new RecursiveSerializer();
            MemoryStream ms = new MemoryStream();
            serializer.Serialize(a, ms);
            ms.Position = 0;
            ClassA deserlizedA = (ClassA)serializer.Deserialize(ms);
            Assert.AreEqual(deserlizedA.ClassB.ClassA.ClassB.ClassA, deserlizedA);
            Assert.AreEqual<string>(deserlizedA.Serialize(new ObjectIDGenerator(), ','), a.Serialize(new ObjectIDGenerator(), ','));
        }

        [TestMethod]
        public void SerializationClassAMethodTest()
        {
            ClassA a = new ClassA();
            ClassB b = new ClassB();
            a.ClassB = b;
            b.ClassA = a;
            string result = a.Serialize(new ObjectIDGenerator(), '$');
            Assert.AreEqual<string>("UnitTestZadanie2.ClassA$1$Opis 1$2>UnitTestZadanie2.ClassB$2$Opis 2$1", a.Serialize(new ObjectIDGenerator(), '$'));
        }

        [TestMethod]
        public void SerializationClassBMethodTest()
        {
            ClassA a = new ClassA();
            ClassB b = new ClassB();
            a.ClassB = b;
            b.ClassA = a;
            string result = b.Serialize(new ObjectIDGenerator(), ';');
            Assert.AreEqual<string>("UnitTestZadanie2.ClassB;1;Opis 2;2>UnitTestZadanie2.ClassA;2;Opis 1;1", b.Serialize(new ObjectIDGenerator(), ';'));
        }
    }
}
