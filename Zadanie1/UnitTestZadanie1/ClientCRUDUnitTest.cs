using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace UnitTestZadanie1
{
    [TestClass]
    public class ClientCRUDUnitTest
    {
        [TestMethod]
        public void AddClientTest()
        {
            DataContext dataContext = new DataContext();
            ConstantDataFiller constantDataFiller = new ConstantDataFiller();
            DataRepository dataRepository = new DataRepository(dataContext, constantDataFiller);

            Client client = new Client("Janusz", "Tracz", "128945");
            dataRepository.AddClient(client);
            Assert.AreEqual(dataContext.clients[dataContext.clients.Count - 1], client);
        }
        [TestMethod]
        public void GetClientTest()
        {
            DataContext dataContext = new DataContext();
            ConstantDataFiller constantDataFiller = new ConstantDataFiller();
            DataRepository dataRepository = new DataRepository(dataContext, constantDataFiller);

            Client client = new Client("Janusz", "Tracz", "128945");
            dataContext.clients.Add(client);
            Assert.AreEqual(dataRepository.GetClient(dataContext.clients.Count - 1), client);
        }
        [TestMethod]
        public void GetAllClientsTest()
        {
            DataContext dataContext = new DataContext();
            ConstantDataFiller constantDataFiller = new ConstantDataFiller();
            DataRepository dataRepository = new DataRepository(dataContext, constantDataFiller);

            List<Client> list = (dataRepository.GetAllClients()).ToList();
            List<Client> list2 = new List<Client>();
            list2.Add(new Client("John", "Hancock", "216834"));
            list2.Add(new Client("Holy", "Hancock", "215912"));
            list2.Add(new Client("John", "Smith", "217632"));
            list2.Add(new Client("Holy", "Smith", "216143"));
            Assert.AreEqual(list.Count(), list2.Count);
            for (int i = 0; i < list.Count(); i++)
                Assert.AreEqual(list[i], list2[i]);
        }
        [TestMethod]
        public void DeleteClientTest()
        {
            DataContext dataContext = new DataContext();
            ConstantDataFiller constantDataFiller = new ConstantDataFiller();
            DataRepository dataRepository = new DataRepository(dataContext, constantDataFiller);

            Client client = new Client("Janusz", "Tracz", "128945");
            dataContext.clients.Add(client);
            int size1 = dataContext.clients.Count();
            Assert.IsTrue(dataContext.clients.Contains(client));
            dataRepository.DeleteClient(client);
            Assert.AreEqual(dataContext.clients.Count, size1 - 1 );
            Assert.IsFalse(dataContext.clients.Contains(client));

        }

    }
}
