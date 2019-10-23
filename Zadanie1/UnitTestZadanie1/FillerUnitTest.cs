using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace UnitTestZadanie1
{
    [TestClass]
    public class FillerUnitTest
    {
        [TestMethod]
        public void ConstantFillerTest()
        {
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, new ConstantDataFiller());

            Assert.AreEqual(dataContext.clients[0], new Client("John", "Hancock", "216834"));
            Assert.AreEqual(dataContext.clients[1], new Client("Holy", "Hancock", "215912"));
            Assert.AreEqual(dataContext.clients[2], new Client("John", "Smith", "217632"));
            Assert.AreEqual(dataContext.clients[3], new Client("Holy", "Smith", "216143"));

            Assert.AreEqual(dataContext.books[686], new Book("Michelle Obama", "Becoming", 686));
            Assert.AreEqual(dataContext.books[524], new Book("Tara Westover", "Tara Westover", 524));
            Assert.AreEqual(dataContext.books[125], new Book("Mark R. Levin", "Unfreedom of the Press", 125));
            Assert.AreEqual(dataContext.books[666], new Book("Jake Richards", "Backwoods Witchcraft", 666));

            Assert.AreEqual(dataContext.bookStates[0], new BookState(dataContext.books[686], 10, 27.59f, 23, "XRA"));
            Assert.AreEqual(dataContext.bookStates[1], new BookState(dataContext.books[524], 5, 30.49f, 23, "35D"));
            Assert.AreEqual(dataContext.bookStates[2], new BookState(dataContext.books[125], 10, 39.99f, 23, "45Z"));
            Assert.AreEqual(dataContext.bookStates[3], new BookState(dataContext.books[666], 10, 21.99f, 23, "15T"));

            Assert.AreEqual(dataContext.events[0], new Event(dataContext.clients[0], dataContext.bookStates[0], new DateTime(2019, 10, 15), 10, true));
            Assert.AreEqual(dataContext.events[1], new Event(dataContext.clients[1], dataContext.bookStates[1], new DateTime(2019, 10, 12), 8, true));
            Assert.AreEqual(dataContext.events[2], new Event(dataContext.clients[0], dataContext.bookStates[2], new DateTime(2019, 10, 11), 7, true));
        }
    }
}
