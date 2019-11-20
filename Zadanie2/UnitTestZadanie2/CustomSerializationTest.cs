using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;
using Zadanie2;
using ConsoleApp1;

namespace UnitTestZadanie2
{
    [TestClass]
    public class CustomSerializationTest
    {
        [TestMethod]
        public void TestWholeDataContextSerialization()
        {
            string path = "./test7.csv";
            DataContext context = ConstantDataFiller.Fill();
            CustomSerializer serializer = new CustomSerializer();
            serializer.Serialize(context, path);
            DataContext deserializedContext = serializer.Deserialize(path);
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

        [TestMethod]
        public void ClientSerializationTest()
        {
            string path = "./test8.csv";
            DataContext context = ConstantDataFiller.Fill();

            context.clients.Add(new Client("John", "Hancock", "216834"));
            context.clients.Add(new Client("Holy", "Hancock", "215912"));
            context.clients.Add(new Client("John", "Smith", "217632"));
            context.clients.Add(new Client("Holy", "Smith", "216143"));
            CustomSerializer serializer = new CustomSerializer();
            serializer.Serialize(context, path);
            DataContext deserializedContext = serializer.Deserialize(path);

            for (int index = 0; index < context.clients.Count; index++)
            {
                Assert.AreEqual<Client>(context.clients[index], deserializedContext.clients[index]);
            }


        }

        [TestMethod]
        public void BookSerializationTest()
        {
            string path = "./test9.csv";
            DataContext context = ConstantDataFiller.Fill();

            context.books.Add(new Book("Michelle Obama", "Becoming", 686));
            context.books.Add(new Book("Tara Westover", "Tara Westover", 524));
            context.books.Add(new Book("Mark R. Levin", "Unfreedom of the Press", 125));
            context.books.Add(new Book("Jake Richards", "Backwoods Witchcraft", 666));
            CustomSerializer serializer = new CustomSerializer();
            serializer.Serialize(context, path);
            DataContext deserializedContext = serializer.Deserialize(path);

            for (int index = 0; index < context.books.Count; index++)
            {
                Assert.AreEqual<Book>(context.books[index], deserializedContext.books[index]);
            }
        }

        [TestMethod]
        public void BookStateTest()
        {
            string path = "./test10.csv";
            DataContext context = ConstantDataFiller.Fill();
            context.books.Add(new Book("Michelle Obama", "Becoming", 686));
            context.books.Add(new Book("Tara Westover", "Tara Westover", 524));
            context.books.Add(new Book("Mark R. Levin", "Unfreedom of the Press", 125));
            context.books.Add(new Book("Jake Richards", "Backwoods Witchcraft", 666));

            context.bookStates.Add(new BookState(context.books[0], 10, 27.59f, 23, "XRA"));
            context.bookStates.Add(new BookState(context.books[1], 5, 30.49f, 23, "35D"));
            context.bookStates.Add(new BookState(context.books[2], 10, 39.99f, 23, "45Z"));
            context.bookStates.Add(new BookState(context.books[3], 10, 21.99f, 23, "15T"));
            CustomSerializer serializer = new CustomSerializer();
            serializer.Serialize(context, path);
            DataContext deserializedContext = serializer.Deserialize(path);

            for (int index = 0; index < context.bookStates.Count; index++)
            {
                Assert.AreEqual<BookState>(context.bookStates[index], deserializedContext.bookStates[index]);
            }
        }

    }
}
