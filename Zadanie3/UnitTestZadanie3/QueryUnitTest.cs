using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;

namespace UnitTestZadanie3
{
    [TestClass]
    public class QueryUnitTest
    {
        [TestMethod]
        public void GetProductsByNameTest()
        {
            List<Product> list = QueriesClass.GetProductsByName("lov");

            List<int> productIDs = new List<int>() { 863, 862, 861, 860, 859, 858 };
            List<string> productNames = new List<string> { "Full-Finger Gloves, L", "Full-Finger Gloves, M",
                "Full-Finger Gloves, S", "Half-Finger Gloves, L", "Half-Finger Gloves, M", "Half-Finger Gloves, S" };

            Assert.AreEqual(list.Count, 6);

            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(productIDs[i], list[i].ProductID);
                Assert.AreEqual(productNames[i], list[i].Name);
            }
        }

        [TestMethod]
        public void GetProductsByVendorNameTest()
        {
            List<Product> list = QueriesClass.GetProductsByVendorName("SUPERSALES INC.");

            Assert.AreEqual(list.Count, 2);

            List<int> productIDs = new List<int>() { 326, 325 };
            List<string> productNames = new List<string> { "Decal 2", "Decal 1"};

            Assert.AreEqual(list.Count, 2);

            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(productIDs[i], list[i].ProductID);
                Assert.AreEqual(productNames[i], list[i].Name);
            }
        }

        [TestMethod]
        public void GetProductNamesByVendorNameTest()
        {
            List<string> list = QueriesClass.GetProductNamesByVendorName("SUPERSALES INC.");

            List<string> productNames = new List<string> { "Decal 2", "Decal 1" };

            Assert.AreEqual(list.Count, 2);

            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(productNames[i], list[i]);
            }
        }

        [TestMethod]
        public void GetProductVendorByProductNameTest()
        {
            string vendorName = QueriesClass.GetProductVendorByProductName("Thin-Jam Hex Nut 1");

            Assert.AreEqual(vendorName, "Advanced Bicycles");
        }

        [TestMethod]
        public void GetProductsWithNRecentReviewsTest()
        {
            List<Product> list = QueriesClass.GetProductsWithNRecentReviews(1);

            Assert.AreEqual(list.Count, 2);
            Assert.AreEqual(list[0].ProductID, 709);
            Assert.AreEqual(list[1].ProductID, 798);
        }

        [TestMethod]
        public void GetNRecentlyReviewedProducts()
        {
            List<Product> list = QueriesClass.GetNRecentlyReviewedProducts(3);

            Assert.AreEqual(list.Count, 3);
            Assert.AreEqual(list[0].ProductID, 937);
            Assert.AreEqual(list[1].ProductID, 798);
            Assert.AreEqual(list[2].ProductID, 937);
        }

        [TestMethod]
        public void GetNProductsFromCategoryTest()
        {
            List<Product> list = QueriesClass.GetNProductsFromCategory("Accessories" , 7);

            List<int> productIDs = new List<int>() { 879, 877, 843, 878,847,848, 876};
            List<string> productNames = new List<string> {"All-Purpose Bike Stand", "Bike Wash - Dissolver", "Cable Lock",
                "Fender Set - Mountain", "Headlights - Dual-Beam","Headlights - Weatherproof","Hitch Rack - 4-Bike"};

            Assert.AreEqual(list.Count, 7);

            for (int i=0; i<list.Count; i++)
            {
                Assert.AreEqual(productIDs[i], list[i].ProductID);
                Assert.AreEqual(productNames[i], list[i].Name);
            }
           
        }

        [TestMethod]
        public void GetTotalStandardCostByCategoryTest() {

            int suma = QueriesClass.GetTotalStandardCostByCategory("Clothing");

            Assert.AreEqual(suma, 868);
        }

    }
}
