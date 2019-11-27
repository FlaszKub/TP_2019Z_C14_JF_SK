using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie2;
using CustomSerialization;
namespace UnitTestZadanie2
{
    [TestClass]
    public class NewCustomSerializationTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ClassA a1 = new ClassA("Ala", 3.12f, new DateTime(2019, 12, 24, 8, 12, 0));
            ClassB b1 = new ClassB("ma", 4.12f, new DateTime(2019, 12, 25, 8, 15, 0));
            ClassC c1 = new ClassC("kota", 5.12f, new DateTime(2019, 12, 26, 8, 20, 0));
            a1.ClassB = b1;
            a1.ClassC = c1;

            b1.ClassA = a1;
            b1.ClassC = c1;

            c1.ClassB = b1;
            c1.ClassA = a1;

            ClassA a2;
            MyFormatter myFormatter = new MyFormatter();
            using (FileStream writeStream = new FileStream("testf2.csv", FileMode.Create))
            {
                myFormatter.Serialize(writeStream, a1);
            }
            using (FileStream readStream = new FileStream("testf2.csv", FileMode.Open)) {
                a2 =(ClassA) myFormatter.Deserialize(readStream);
            }
            ClassB b2 = a2.ClassB;
            ClassC c2 = a2.ClassC;
            Assert.AreEqual(a1.Name,a2.Name);
            Assert.AreEqual(b1.Name,b2.Name);
            Assert.AreEqual(c1.Name,c2.Name);
            Assert.AreEqual(a1.Num,a2.Num);
            Assert.AreEqual(b1.Num,b2.Num);
            Assert.AreEqual(c1.Num,c2.Num);
            Assert.AreEqual(a1.Date,a2.Date);
            Assert.AreEqual(b1.Date,b2.Date);
            Assert.AreEqual(c1.Date,c2.Date);
            Assert.AreEqual(b2.ClassA, a2);
            Assert.AreEqual(b2.ClassC, c2);
            Assert.AreEqual(c2.ClassA, a2);
            Assert.AreEqual(c2.ClassB, b2);
        }
    }
}
