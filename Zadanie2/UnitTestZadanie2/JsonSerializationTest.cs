using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;
using Zadanie2;

namespace UnitTestZadanie2
{
    [TestClass]
    public class JsonSerializationTest
    {
        [TestMethod]
        public void TestSerialization()
        {
            string path = "./test.json";
            DataContext context = ConstantDataFiller.Fill();
            JsonSerializer serializing = new JsonSerializer();
            serializing.Serialize(context, path);
            DataContext deserializedContext = serializing.DeserializeToDataContext(path);
            Assert.AreEqual<int>(context.books.Count, deserializedContext.books.Count);
            Assert.AreEqual<int>(context.bookStates.Count, deserializedContext.bookStates.Count);
            Assert.AreEqual<int>(context.clients.Count, deserializedContext.clients.Count);
            Assert.AreEqual<int>(context.events.Count, deserializedContext.events.Count);

            for (int index = 0; index < context.books.Count; index++)
            {
                Assert.AreEqual<Book>(context.books[index], deserializedContext.books[index]);
            }

            for (int index = 0; index < context.bookStates.Count; index++)
            {
                Assert.AreEqual<BookState>(context.bookStates[index], deserializedContext.bookStates[index]);
            }

            for (int index = 0; index < context.clients.Count; index++)
            {
                Assert.AreEqual<Client>(context.clients[index], deserializedContext.clients[index]);
            }

            for (int index = 0; index < context.events.Count; index++)
            {
                Assert.AreEqual<Event>(context.events[index], deserializedContext.events[index]);
                if (index < 4)
                {
                    Assert.IsTrue(deserializedContext.events[index] is Purchase);
                }
                else
                {
                    Assert.IsTrue(deserializedContext.events[index] is Sale);
                }
            }

        }
    }
}
