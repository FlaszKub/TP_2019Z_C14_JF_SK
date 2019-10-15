using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace UnitTestZadanie1
{
    [TestClass]
    public class SpecimenUnitTest
    {
        [TestMethod]
        public void CtorTest()
        {
            Book book = new Book("Tom", "C#Start", 455);
            DateTimeOffset date = new DateTimeOffset(new DateTime(2019, 10, 15));
            Specimen specimen = new Specimen(book, date, 23.5f, 23,"XRA");
            Assert.AreEqual<Book>(book, specimen.Book);
            Assert.AreEqual<DateTimeOffset>(date, specimen.DateOfPurchase);
            Assert.AreEqual<float>(23.5f, specimen.NetPrice);
            Assert.AreEqual<int>(23, specimen.Tax);
            Assert.AreEqual<string>("XRA", specimen.Id);
        }

        [TestMethod]
        public void SetterTest()
        {
            Specimen specimen = new Specimen(null, new DateTimeOffset(), 0, 0, null);
            Book book = new Book("Tom", "C#Start", 455);
            specimen.Book = book;
            Assert.AreEqual<Book>(book, specimen.Book);
            DateTimeOffset date = new DateTimeOffset(new DateTime(2019, 10, 15));
            specimen.DateOfPurchase = date;
            Assert.AreEqual<DateTimeOffset>(date, specimen.DateOfPurchase);
            specimen.NetPrice = 25.6f;
            Assert.AreEqual<float>(25.6f, specimen.NetPrice);
            specimen.Tax = 10;
            Assert.AreEqual<int>(10, specimen.Tax);
            specimen.Id = "RXX";
            Assert.AreEqual<string>("RXX", specimen.Id);
        }
    }
}
