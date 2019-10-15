using Zadanie1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestZadanie1
{
    [TestClass]
    public class ClientUnitTest
    {
        [TestMethod]
        public void CtorTest()
        {
            Client client = new Client("Tom", "Cat", "216754");
            Assert.AreEqual<string>("Tom", client.FirstName);
            Assert.AreEqual<string>("Cat", client.LastName);
            Assert.AreEqual<string>("216754", client.Id);
        }

        [TestMethod]
        public void SettersTest()
        {
            Client client = new Client(null, null, null);
            client.FirstName = "Visual";
            Assert.AreEqual<string>("Visual", client.FirstName);
            client.LastName = "Studio";
            Assert.AreEqual<string>("Studio", client.LastName);
            client.Id = "2017";
            Assert.AreEqual<string>("2017", client.Id);
        }
    }
}
