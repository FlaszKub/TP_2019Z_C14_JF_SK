using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace ModelUnitTest
{
    [TestClass]
    public class DataBaseTest
    {
        [TestMethod]
        public void GetTest()
        {
            DataContext dataContext = new DataContext();
            Product p = dataContext.Get(2);
            Assert.AreEqual<String>("Bearing Ball", p.Name);
            Assert.AreEqual<int>(2, p.ProductID);
        }

        [TestMethod]
        public void UpdateTest()
        {
            DataContext dataContext = new DataContext();
            Product p = dataContext.Get(2);
            p.Name = "Kuba";
            dataContext.Update(p);
            Assert.AreEqual<String>("Kuba", dataContext.Get(2).Name);
        }


        [ClassCleanup]
        public static void cleanUp()
        {
            ProductionDataContext production = new ProductionDataContext();
            Product product = production.Products.Where(p => p.ProductID == 2).First();
            product.Name = "Bearing Ball";
            production.SubmitChanges();
        }
    }
}
