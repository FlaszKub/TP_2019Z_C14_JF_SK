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
                List<Product> answer = products.GetProductsWithoutCategoryLambda();
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

        [TestMethod]
        public void ListPGetVendorProductListQueryTest()
        {
            using (ProductionDataContext dataContext = new ProductionDataContext())
            {
                List<Product> products = dataContext.GetTable<Product>().ToList();
                List<ProductVendor> vendors = dataContext.GetTable<ProductVendor>().ToList();

                string answer = products.GetVendorProductListQuery(vendors);
                string[] lines = answer.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                Assert.IsTrue(lines.Contains("Thin-Jam Hex Nut 16-Advanced Bicycles"));
                Assert.IsTrue(lines.Contains("HL Crankarm-West Junction Cycles"));
                Assert.IsTrue(lines.Contains("LL Crankarm-Vision Cycles, Inc."));
                Assert.AreEqual(460, lines.Length);
            }
        }

        [TestMethod]
        public void pageTest()
        {
            using (ProductionDataContext dataContext = new ProductionDataContext())
            {
                List<Product> products = dataContext.GetTable<Product>().ToList();
                List<Product> result = products.GetProductsAsPage(2, 25);
                Assert.AreEqual<int>(25, result.Count);
                result = products.GetProductsAsPage(3, 50);
                Assert.AreEqual<int>(50, result.Count);
            }
        }

    }
}
