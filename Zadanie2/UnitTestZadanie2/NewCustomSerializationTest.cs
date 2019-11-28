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
        private ClassA a1;
        private ClassB b1;
        private ClassC c1;
        private MyFormatter myFormatter;

        [TestInitialize]
        public void TestInitialize()
        {
            myFormatter = new MyFormatter();
            a1 = new ClassA("Ala", 3.12f, new DateTime(2019, 12, 24, 8, 12, 0));
            b1 = new ClassB("ma", 4.12f, new DateTime(2019, 12, 25, 8, 15, 0));
            c1 = new ClassC("kota", 5.12f, new DateTime(2019, 12, 26, 8, 20, 0));
            a1.ClassB = b1;
            a1.ClassC = c1;

            b1.ClassA = a1;
            b1.ClassC = c1;

            c1.ClassB = b1;
            c1.ClassA = a1;
        }

        [TestMethod]
        public void ClassANullSerializtionTest()
        {

            ClassA a2;
            a1.ClassB = null;
            a1.ClassC = null;
            using (FileStream writeStream = new FileStream("testf2.csv", FileMode.Create))
            {
                myFormatter.Serialize(writeStream, a1);
            }
            using (FileStream readStream = new FileStream("testf2.csv", FileMode.Open))
            {
                a2 = (ClassA)myFormatter.Deserialize(readStream);
            }
            Assert.AreEqual(a1.Name, a2.Name);

            Assert.AreEqual(a1.Num, a2.Num);

            Assert.AreEqual(a1.Date, a2.Date);

            Assert.AreSame(a2.ClassB, null);
            Assert.AreSame(a2.ClassC, null);
        }

        [TestMethod]
        public void ClassASerializtionTest()
        {
            
            ClassA a2;
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

            Assert.AreSame(b2.ClassA, a2);
            Assert.AreSame(b2.ClassC, c2);
            Assert.AreSame(c2.ClassA, a2);
            Assert.AreSame(c2.ClassB, b2);
        }

        [TestMethod]
        public void ClassBNullSerializtionTest()
        {

            ClassB b2;
            b1.ClassA = null;
            b1.ClassC = null;
            using (FileStream writeStream = new FileStream("testf2.csv", FileMode.Create))
            {
                myFormatter.Serialize(writeStream, b1);
            }
            using (FileStream readStream = new FileStream("testf2.csv", FileMode.Open))
            {
                b2 = (ClassB)myFormatter.Deserialize(readStream);
            }
            Assert.AreEqual(b1.Name, b2.Name);

            Assert.AreEqual(b1.Num, b2.Num);

            Assert.AreEqual(b1.Date, b2.Date);

            Assert.AreSame(b2.ClassA, null);
            Assert.AreSame(b2.ClassC, null);
        }

        [TestMethod]
        public void ClassBSerializtionTest()
        {

            ClassB b2;

            using (FileStream writeStream = new FileStream("testf2.csv", FileMode.Create))
            {
                myFormatter.Serialize(writeStream, b1);
            }
            using (FileStream readStream = new FileStream("testf2.csv", FileMode.Open))
            {
                b2 = (ClassB) myFormatter.Deserialize(readStream);
            }
            ClassA a2 = b2.ClassA;
            ClassC c2 = b2.ClassC;
            Assert.AreEqual(a1.Name, a2.Name);
            Assert.AreEqual(b1.Name, b2.Name);
            Assert.AreEqual(c1.Name, c2.Name);

            Assert.AreEqual(a1.Num, a2.Num);
            Assert.AreEqual(b1.Num, b2.Num);
            Assert.AreEqual(c1.Num, c2.Num);

            Assert.AreEqual(a1.Date, a2.Date);
            Assert.AreEqual(b1.Date, b2.Date);
            Assert.AreEqual(c1.Date, c2.Date);

            Assert.AreSame(a2.ClassB, b2);
            Assert.AreSame(a2.ClassC, c2);
            Assert.AreSame(c2.ClassA, a2);
            Assert.AreSame(c2.ClassB, b2);
        }

        [TestMethod]
        public void ClassCNullSerializtionTest()
        {

            ClassC c2;
            c1.ClassA = null;
            c1.ClassB = null;
            using (FileStream writeStream = new FileStream("testf2.csv", FileMode.Create))
            {
                myFormatter.Serialize(writeStream, c1);
            }
            using (FileStream readStream = new FileStream("testf2.csv", FileMode.Open))
            {
                c2 = (ClassC)myFormatter.Deserialize(readStream);
            }
            Assert.AreEqual(c1.Name, c2.Name);

            Assert.AreEqual(c1.Num, c2.Num);

            Assert.AreEqual(c1.Date, c2.Date);

            Assert.AreSame(c2.ClassB, null);
            Assert.AreSame(c2.ClassA, null);
        }


        [TestMethod]
        public void ClassCSerializtionTest()
        {

            ClassC c2;

            using (FileStream writeStream = new FileStream("testf2.csv", FileMode.Create))
            {
                myFormatter.Serialize(writeStream, c1);
            }
            using (FileStream readStream = new FileStream("testf2.csv", FileMode.Open))
            {
                c2 = (ClassC)myFormatter.Deserialize(readStream);
            }
            ClassA a2 = c2.ClassA;
            ClassB b2 = c2.ClassB;
            Assert.AreEqual(a1.Name, a2.Name);
            Assert.AreEqual(b1.Name, b2.Name);
            Assert.AreEqual(c1.Name, c2.Name);

            Assert.AreEqual(a1.Num, a2.Num);
            Assert.AreEqual(b1.Num, b2.Num);
            Assert.AreEqual(c1.Num, c2.Num);

            Assert.AreEqual(a1.Date, a2.Date);
            Assert.AreEqual(b1.Date, b2.Date);
            Assert.AreEqual(c1.Date, c2.Date);

            Assert.AreSame(a2.ClassB, b2);
            Assert.AreSame(a2.ClassC, c2);
            Assert.AreSame(b2.ClassA, a2);
            Assert.AreSame(b2.ClassC, c2);
        }
    }
}
