using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace UnitTestZadanie1
{
    [TestClass]
    public class EventCRUDUnitTest
    {
        [TestMethod]
        public void AddEventTest()
        {
            DataContext dataContext = new DataContext();
            ConstantDataFiller constantDataFiller = new ConstantDataFiller();
            DataRepository dataRepository = new DataRepository(dataContext, constantDataFiller);

            Client client = new Client("Ala", "Kot", "2234");
            Book book = new Book("J R R Tolkien", "Hobbit", 1);
            DateTimeOffset date = new DateTimeOffset(new DateTime(2019, 10, 15));
            BookState bookState = new BookState(book, 5, 45.3f, 10, "XRA");
            Event saleEvent = new Sale(client, bookState, date, 2);
            dataRepository.AddEvent(saleEvent);
            Assert.AreEqual(dataContext.events[dataContext.events.Count - 1], saleEvent);
        }
        [TestMethod]
        public void GetEventTest()
        {
            DataContext dataContext = new DataContext();
            ConstantDataFiller constantDataFiller = new ConstantDataFiller();
            DataRepository dataRepository = new DataRepository(dataContext, constantDataFiller);

            Client client = new Client("Ala", "Kot", "2234");
            Book book = new Book("J R R Tolkien", "Hobbit", 1);
            DateTimeOffset date = new DateTimeOffset(new DateTime(2019, 10, 15));
            BookState bookState = new BookState(book, 5, 45.3f, 10, "XRA");
            Event saleEvent = new Sale(client, bookState, date, 2);
            dataContext.events.Add(saleEvent);
            Assert.AreEqual(dataRepository.GetEvent(dataContext.events.Count - 1), saleEvent);
        }
        [TestMethod]
        public void GetAllEventsTest()
        {
            DataContext dataContext = new DataContext();
            ConstantDataFiller constantDataFiller = new ConstantDataFiller();
            DataRepository dataRepository = new DataRepository(dataContext, constantDataFiller);

            List<Event> list = (dataRepository.GetAllEvents()).ToList();
            List<Event> list2 = new List<Event>();
            list2.Add(new Purchase(dataContext.clients[0], dataContext.bookStates[0], new DateTime(2019, 10, 15), 10));
            list2.Add(new Purchase(dataContext.clients[1], dataContext.bookStates[1], new DateTime(2019, 10, 12), 8));
            list2.Add(new Purchase(dataContext.clients[0], dataContext.bookStates[2], new DateTime(2019, 10, 11), 7));
            list2.Add(new Purchase(dataContext.clients[1], dataContext.bookStates[3], new DateTime(2019, 10, 9), 6));

            list2.Add(new Sale(dataContext.clients[2], dataContext.bookStates[1], new DateTime(2019, 10, 21), 1));
            list2.Add(new Sale(dataContext.clients[3], dataContext.bookStates[0], new DateTime(2019, 10, 1), 4));
            list2.Add(new Sale(dataContext.clients[0], dataContext.bookStates[3], new DateTime(2019, 10, 5), 1));
            list2.Add(new Sale(dataContext.clients[2], dataContext.bookStates[3], new DateTime(2019, 10, 7), 2));
            Assert.AreEqual(list.Count(), list2.Count);
            for (int i=0; i < list.Count(); i++)
            Assert.AreEqual(list[i], list2[i]);
            
        }
        [TestMethod]
        public void DeleteEventTest()
        {
            DataContext dataContext = new DataContext();
            ConstantDataFiller constantDataFiller = new ConstantDataFiller();
            DataRepository dataRepository = new DataRepository(dataContext, constantDataFiller);

            Client client = new Client("Ala", "Kot", "2234");
            Book book = new Book("J R R Tolkien", "Hobbit", 1);
            DateTimeOffset date = new DateTimeOffset(new DateTime(2019, 10, 15));
            BookState bookState = new BookState(book, 5, 45.3f, 10, "XRA");
            Event saleEvent = new Sale(client, bookState, date, 2);
            dataContext.events.Add(saleEvent);
            int size1 = dataContext.events.Count();
            Assert.IsTrue(dataContext.events.Contains(saleEvent));
            dataRepository.DeleteEvent(saleEvent);
            Assert.AreEqual(dataContext.events.Count, size1 - 1);
            Assert.IsFalse(dataContext.events.Contains(saleEvent));

        }
    }
}
