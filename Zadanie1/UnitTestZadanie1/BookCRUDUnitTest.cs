using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace UnitTestZadanie1
{
    [TestClass]
    public class BookCRUDUnitTest
    {
        [TestMethod]
        public void AddBookTest()
        {
            DataContext dataContext = new DataContext();
            ConstantDataFiller constantDataFiller = new ConstantDataFiller();
            DataRepository dataRepository = new DataRepository(dataContext, constantDataFiller);
            Book book = new Book("H.P. Lovecraft", "Call of Cthulhu", 623);
            dataRepository.AddBook(book);
            Assert.AreEqual(dataContext.books[book.KeyNumber], book);
        }
        [TestMethod]
        public void GetBookTest()
        {
            DataContext dataContext = new DataContext();
            ConstantDataFiller constantDataFiller = new ConstantDataFiller();
            DataRepository dataRepository = new DataRepository(dataContext, constantDataFiller);

            Book book = new Book("H.P. Lovecraft", "Call of Cthulhu", 623);
            dataContext.books.Add(book.KeyNumber, book);
            Assert.AreEqual(dataRepository.GetBook(book.KeyNumber), book);
        }
        [TestMethod]
        public void GetAllBooksTest()
        {
            DataContext dataContext = new DataContext();
            ConstantDataFiller constantDataFiller = new ConstantDataFiller();
            DataRepository dataRepository = new DataRepository(dataContext, constantDataFiller);

            List<Book> list = (dataRepository.GetAllBooks()).ToList();
            List<Book> list2 = new List<Book>();
            list2.Add(new Book("Michelle Obama", "Becoming", 686));
            list2.Add(new Book("Tara Westover", "Tara Westover", 524));
            list2.Add(new Book("Mark R. Levin", "Unfreedom of the Press", 125));
            list2.Add(new Book("Jake Richards", "Backwoods Witchcraft", 666));
            Assert.AreEqual(list[0], list2[0]);
            Assert.AreEqual(list[1], list2[1]);
            Assert.AreEqual(list[2], list2[2]);
            Assert.AreEqual(list[3], list2[3]);
        }
        [TestMethod]
        public void DeleteClientTest()
        {
            DataContext dataContext = new DataContext();
            ConstantDataFiller constantDataFiller = new ConstantDataFiller();
            DataRepository dataRepository = new DataRepository(dataContext, constantDataFiller);

            Book book = new Book("H.P. Lovecraft", "Call of Cthulhu", 623);
            dataContext.books.Add(book.KeyNumber, book);
            int size1 = dataContext.books.Count();
            Assert.IsTrue(dataContext.books.ContainsValue(book));
            dataRepository.DeleteBook(book.KeyNumber);
            Assert.AreEqual(dataContext.books.Count, size1 - 1);
            Assert.IsFalse(dataContext.books.ContainsValue(book));
        }
    }
}
