using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class DataContextTest
    {
        [TestMethod]
        public void GetTest()
        {
            DataContext dataContext = new DataContext();
            Product p = dataContext.Get(316);
            Assert.AreEqual<String>("Blade", p.Name);
            Assert.AreEqual<int>(316, p.ProductID);
        }

        [TestMethod]
        public void UpdateTest()
        {
            DataContext dataContext = new DataContext();
            Product p = dataContext.Get(316);
            p.Name = "Kuba";
            dataContext.Update(p);
            Assert.AreEqual<String>("Kuba", dataContext.Get(316).Name);
        }


        [ClassCleanup]
        public static void cleanUp()
        {
            ProductionDataContext production = new ProductionDataContext();
            Product product = production.Products.Where(p => p.ProductID == 316).First();
            product.Name = "Blade";
            production.SubmitChanges();
        }
    }
}
