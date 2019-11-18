using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace UnitTestZadanie2
{
    [TestClass]
    public class FillTest
    {
        [TestMethod]
        public void TestConstantDataFiler()
        {
            DataContext context = ConstantDataFiller.Fill();
            Assert.AreEqual<int>(4, context.books.Count);
            Assert.AreEqual<int>(4, context.bookStates.Count);
            Assert.AreEqual<int>(4, context.clients.Count);
            Assert.AreEqual<int>(8, context.events.Count);
        }
    }
}
