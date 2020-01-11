using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTestZadanie3
{
    [TestClass]
    public class MyProductsDataContextTests
    {
        private List<MyProduct> insertProductsFromBase()
        {
            ProductionDataContext db = new ProductionDataContext();
            Table<Product> products = db.GetTable<Product>();
            List<Product> result = (from product in products
                                    select product).ToList();
            return (from product in result
                    select new MyProduct(product)).ToList();
        }

        [TestMethod]
        public void GetMyProductsByNameTest()
        {
            MyProductDataContext dataContext = new MyProductDataContext(insertProductsFromBase());
            List<MyProduct> products = dataContext.GetMyProductsByName("lov");
            List<MyProduct> products3 = dataContext.GetMyProductsByName("test");
            Assert.AreEqual(6, products.Count);
            Assert.AreEqual(0, products3.Count);

        }

        [TestMethod]
        public void GetNMyProductFromCategoryTest()
        {
            MyProductDataContext myProductDataContext = new MyProductDataContext(insertProductsFromBase());

            List<MyProduct> list = myProductDataContext.GetNMyProductFromCategory("Bikes", 3);
            Assert.AreEqual(list.Count, 3);
            Assert.AreEqual(list[0].ProductSubcategory.ProductCategory.Name, "Bikes");
            Assert.AreEqual(list[1].ProductSubcategory.ProductCategory.Name, "Bikes");
            Assert.AreEqual(list[2].ProductSubcategory.ProductCategory.Name, "Bikes");
        }

        [TestMethod]
        public void GetMyProductsWithNRecentReviewsTest()
        {
            MyProductDataContext myProductDataContext = new MyProductDataContext(insertProductsFromBase());
            List<MyProduct> list = myProductDataContext.GetMyProductsWithNRecentReviews(1);

            Assert.AreEqual(list.Count, 2);
            Assert.AreEqual(list[0].ProductID, 709);
            Assert.AreEqual(list[1].ProductID, 798);
        }
    }
}
