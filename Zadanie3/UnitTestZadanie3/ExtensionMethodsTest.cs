using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;

namespace UnitTestZadanie3
{
    [TestClass]
    public class ExtensionMethodsTests
    {
        [TestMethod]
        public void GetProductsWithoutCategoryTest()
        {
            using (ProductionDataContext dataContext = new ProductionDataContext())
            {
                List<Product> products = dataContext.GetTable<Product>().ToList();
                List<Product> answer = products.GetProductsWithoutCategory();
                Assert.AreEqual(answer[0].ProductSubcategory, null);
            }
        }

        [TestMethod]
        public void GetProductsWithoutCategoryQueryTest()
        {
            using (ProductionDataContext dataContext = new ProductionDataContext())
            {
                List<Product> products = dataContext.GetTable<Product>().ToList();
                List<Product> answer = products.GetProductsWithoutCategoryQuery();
                Assert.AreEqual(answer[0].ProductSubcategory, null);
            }
        }
    }
}
