using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace UnitTestZadanie1
{
    [TestClass]
    public class BookStateUnitTest
    {
        [TestMethod]
        public void CtorTest()
        {
            Book book = new Book("Tom", "C#Start", 455);
            BookState bookSate = new BookState(book, 10, 23.5f, 23,"XRA");
            Assert.AreEqual<Book>(book, bookSate.Book);
            Assert.AreEqual<int>(10, bookSate.Quantity);
            Assert.AreEqual<float>(23.5f, bookSate.NetPrice);
            Assert.AreEqual<int>(23, bookSate.Tax);
            Assert.AreEqual<string>("XRA", bookSate.Id);
        }

        [TestMethod]
        public void SetterTest()
        {
            BookState bookState = new BookState(null, 0, 0, 0, null);
            Book book = new Book("Tom", "C#Start", 455);
            bookState.Book = book;
            Assert.AreEqual<Book>(book, bookState.Book);
            bookState.Quantity = 15;
            Assert.AreEqual<int>(15, bookState.Quantity);
            bookState.NetPrice = 25.6f;
            Assert.AreEqual<float>(25.6f, bookState.NetPrice);
            bookState.Tax = 10;
            Assert.AreEqual<int>(10, bookState.Tax);
            bookState.Id = "RXX";
            Assert.AreEqual<string>("RXX", bookState.Id);
        }
    }
}
