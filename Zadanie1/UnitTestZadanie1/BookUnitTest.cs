using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace UnitTestZadanie1
{
    [TestClass]
    public class BookUnitTest
    {
        [TestMethod]
        public void CtorTest()
        {
            Book book = new Book("Tom", "C#Start", 455);
            Assert.AreEqual<string>("Tom", book.Author);
            Assert.AreEqual<string>("C#Start", book.Title);
            Assert.AreEqual<int>(455, book.KeyNumber);
        }

        [TestMethod]
        public void SettersTest()
        {
            Book book = new Book(null, null, 0);
            book.Author = "Jerry";
            Assert.AreEqual<string>("Jerry", book.Author);
            book.Title = "Java";
            Assert.AreEqual<string>("Java", book.Title);
            book.KeyNumber = 997;
            Assert.AreEqual<int>(997, book.KeyNumber);
        }
    }
}
