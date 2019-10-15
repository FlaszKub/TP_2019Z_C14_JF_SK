using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace UnitTestZadanie1
{
    [TestClass]
    public class SaleEventUnitTest
    {
        [TestMethod]
        public void CtorTest()
        {
            Client client = new Client("Ala", "Kot", "2234");
            Book book = new Book("J R R Tolkien", "Hobbit", 1);
            DateTimeOffset date = new DateTimeOffset(new DateTime(2019, 10, 15));
            Specimen specimen = new Specimen(book, new DateTimeOffset(new DateTime(2019, 10, 5)), 45.3f, 10, "XRA");
            SaleEvent saleEvent = new SaleEvent(client, specimen, date);
            Assert.AreEqual<Client>(client, saleEvent.Client);
            Assert.AreEqual<Specimen>(specimen, saleEvent.Specimen);
            Assert.AreEqual<DateTimeOffset>(date, saleEvent.SaleDate);
        }

        [TestMethod]
        public void SettersTest()
        {
            SaleEvent saleEvent = new SaleEvent(null, null, new DateTimeOffset());
            Client client = new Client("Ala", "Kot", "2234");
            saleEvent.Client = client;
            Assert.AreEqual<Client>(client, saleEvent.Client);
            Book book = new Book("J R R Tolkien", "Hobbit", 1);
            Specimen specimen = new Specimen(book, new DateTimeOffset(new DateTime(2019, 10, 5)), 45.3f, 10, "XRA");
            saleEvent.Specimen = specimen;
            Assert.AreEqual<Specimen>(specimen, saleEvent.Specimen);
            DateTimeOffset date = new DateTimeOffset(new DateTime(2019, 10, 15));
            saleEvent.SaleDate = date;
            Assert.AreEqual<DateTimeOffset>(date, saleEvent.SaleDate);
        }
    }
}
