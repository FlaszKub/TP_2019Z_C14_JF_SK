using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace UnitTestZadanie1
{
    [TestClass]
    public class BookStateCRUDUnitTest
    {
        [TestMethod]
        public void AddBookStateTest()
        {
            DataContext dataContext = new DataContext();
            ConstantDataFiller constantDataFiller = new ConstantDataFiller();
            DataRepository dataRepository = new DataRepository(dataContext, constantDataFiller);

            Book book = new Book("Tom", "C#Start", 455);
            BookState bookState = new BookState(book, 10, 23.5f, 23, "ORA");
            dataRepository.AddBookState(bookState);
            Assert.AreEqual(dataContext.bookStates[dataContext.bookStates.Count - 1], bookState);
        }
        [TestMethod]
        public void GetBookStateTest()
        {
            DataContext dataContext = new DataContext();
            ConstantDataFiller constantDataFiller = new ConstantDataFiller();
            DataRepository dataRepository = new DataRepository(dataContext, constantDataFiller);

            Book book = new Book("Tom", "C#Start", 455);
            BookState bookState = new BookState(book, 10, 23.5f, 23, "ORA");
            dataContext.bookStates.Add(bookState);
            Assert.AreEqual(dataRepository.GetBookState(dataContext.bookStates.Count - 1), bookState);
        }
        [TestMethod]
        public void GetAllBookStatesTest()
        {
            DataContext dataContext = new DataContext();
            ConstantDataFiller constantDataFiller = new ConstantDataFiller();
            DataRepository dataRepository = new DataRepository(dataContext, constantDataFiller);

            List<BookState> list = (dataRepository.GetAllBookStates()).ToList();
            List<BookState> list2 = new List<BookState>();
            list2.Add(new BookState(dataContext.books[686], 10, 27.59f, 23, "XRA"));
            list2.Add(new BookState(dataContext.books[524], 5, 30.49f, 23, "35D"));
            list2.Add(new BookState(dataContext.books[125], 10, 39.99f, 23, "45Z"));
            list2.Add(new BookState(dataContext.books[666], 10, 21.99f, 23, "15T"));
            Assert.AreEqual(list.Count(), list2.Count);
            for (int i = 0; i < list.Count(); i++)
                Assert.AreEqual(list[i], list2[i]);
        }
        [TestMethod]
        public void DeleteBookStateTest()
        {
            DataContext dataContext = new DataContext();
            ConstantDataFiller constantDataFiller = new ConstantDataFiller();
            DataRepository dataRepository = new DataRepository(dataContext, constantDataFiller);

            Book book = new Book("Tom", "C#Start", 455);
            BookState bookState = new BookState(book, 10, 23.5f, 23, "ORA");
            dataContext.bookStates.Add(bookState);
            int size1 = dataContext.bookStates.Count();
            Assert.IsTrue(dataContext.bookStates.Contains(bookState));
            dataRepository.DeleteBookState(bookState);
            Assert.AreEqual(dataContext.bookStates.Count, size1 - 1);
            Assert.IsFalse(dataContext.bookStates.Contains(bookState));
        }
    }
}
