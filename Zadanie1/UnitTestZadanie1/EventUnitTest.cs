using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace UnitTestZadanie1
{
    [TestClass]
    public class EventUnitTest
    {
        [TestMethod]
        public void CtorTest()
        {
            Client client = new Client("Ala", "Kot", "2234");
            Book book = new Book("J R R Tolkien", "Hobbit", 1);
            DateTimeOffset date = new DateTimeOffset(new DateTime(2019, 10, 15));
            BookState bookState = new BookState(book, 5, 45.3f, 10, "XRA");
            Event saleEvent = new Event(client, bookState, date, 2, false);
            Assert.AreEqual<Client>(client, saleEvent.Client);
            Assert.AreEqual<BookState>(bookState, saleEvent.BookState);
            Assert.AreEqual<DateTimeOffset>(date, saleEvent.Date);
            Assert.AreEqual<bool>(false, saleEvent.IsPurchase);
        }

        [TestMethod]
        public void SettersTest()
        {
            Event saleEvent = new Event(null, null, new DateTimeOffset(), 0, false);
            Client client = new Client("Ala", "Kot", "2234");
            saleEvent.Client = client;
            Assert.AreEqual<Client>(client, saleEvent.Client);
            Book book = new Book("J R R Tolkien", "Hobbit", 1);
            BookState bookState = new BookState(book, 8, 45.3f, 10, "XRA");
            saleEvent.BookState = bookState;
            Assert.AreEqual<BookState>(bookState, saleEvent.BookState);
            DateTimeOffset date = new DateTimeOffset(new DateTime(2019, 10, 15));
            saleEvent.Date = date;
            Assert.AreEqual<DateTimeOffset>(date, saleEvent.Date);
            saleEvent.Quantity = 6;
            Assert.AreEqual<int>(6, saleEvent.Quantity);
        }
    }
}
