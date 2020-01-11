using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTestZadanie3
{
    [TestClass]
    public class QueryUnitTest
    {
        [TestMethod]
        public void GetProductsByNameTest()
        {
            List<Product> list = ProductRepository.GetProductsByName("lov");

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
            List<Product> list = ProductRepository.GetProductsByVendorName("SUPERSALES INC.");

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
            List<string> list = ProductRepository.GetProductNamesByVendorName("SUPERSALES INC.");

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
            string vendorName = ProductRepository.GetProductVendorByProductName("Thin-Jam Hex Nut 1");

            Assert.AreEqual(vendorName, "Advanced Bicycles");
        }

        [TestMethod]
        public void GetProductsWithNRecentReviewsTest()
        {
            List<Product> list = ProductRepository.GetProductsWithNRecentReviews(1);

            Assert.AreEqual(list.Count, 2);
            Assert.AreEqual(list[0].ProductID, 709);
            Assert.AreEqual(list[1].ProductID, 798);
        }

        [TestMethod]
        public void GetNRecentlyReviewedProducts()
        {
            List<Product> list = ProductRepository.GetNRecentlyReviewedProducts(3);

            Assert.AreEqual(list.Count, 3);
            Assert.AreEqual(list[0].ProductID, 937);
            Assert.AreEqual(list[1].ProductID, 798);
            Assert.AreEqual(list[2].ProductID, 709);
        }

        [TestMethod]
        public void GetNProductsFromCategoryTest()
        {
            List<Product> list = ProductRepository.GetNProductsFromCategory("Accessories" , 7);

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

            ProductCategory category = new ProductCategory
            {
                Name = "Clothing"
            };
            int suma = ProductRepository.GetTotalStandardCostByCategory(category);

            Assert.AreEqual(suma, 868);
        }

    }
}
