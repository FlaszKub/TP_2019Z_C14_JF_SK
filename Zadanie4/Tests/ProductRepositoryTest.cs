using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;

namespace Tests
{
    [TestClass]
    public class ProductRepositoryTest
    {
        [TestMethod]
        public void GetColors()
        {
            ProductRepository rep = new ProductRepository();
            List<string> colors = rep.GetColors();
            Assert.AreEqual(10, colors.Count);

        }

        [TestMethod]
        public void GetProductLinesTest()
        {
            ProductRepository rep = new ProductRepository();
            List<string> lines = rep.GetProductLines();
            Assert.AreEqual(5, lines.Count);
        }

        [TestMethod]
        public void GetSizesTest()
        {
            ProductRepository rep = new ProductRepository();
            List<string> sizes = rep.GetSizes();
            Assert.AreEqual(19, sizes.Count);
        }

        [TestMethod]
        public void GetClassesTest()
        {
            ProductRepository rep = new ProductRepository();
            List<string> classes = rep.GetClasses();
            Assert.AreEqual(3, classes.Count);
        }

        [TestMethod]
        public void GetStylesTest()
        {
            ProductRepository rep = new ProductRepository();
            List<string> styles = rep.GetStyles();
            Assert.AreEqual(3, styles.Count);
        }
    }
}
