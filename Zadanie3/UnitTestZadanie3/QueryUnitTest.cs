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
        public void TestMethod1()
        {
            List<Product> lista = QueriesClass.GetProductsByName("Flat");
            
            foreach(Product p in lista)
            {
                Console.WriteLine(p.Name);
            }
        }
    }
}
