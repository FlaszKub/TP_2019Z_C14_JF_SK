using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetTest()
        {
            DataContext dataContext = new DataContext();
            Product p = dataContext.Get(2);
            Assert.AreEqual<String>("Bearing Ball", p.Name);
            Assert.AreEqual<int>(2, p.ProductID);
        }
    }
}
