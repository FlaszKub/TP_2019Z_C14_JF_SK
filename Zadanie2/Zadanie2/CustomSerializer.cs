using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Zadanie1;

namespace Zadanie2
{
    public class CustomSerializer
    {       
        private readonly char separator = ';';
        public CustomSerializer(){ }
        public void Serialize(DataContext dataContext, String path) {
            ObjectIDGenerator gen = new ObjectIDGenerator();
            string serialized = SerializeToString(dataContext, gen);
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (StreamWriter output = new StreamWriter(fs))
                {
                    output.WriteLine(serialized);
                }
            }
        }

        public DataContext Deserialize(String path)
        {
            List<string[]> Deserialized = new List<string[]>();           
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                using (StreamReader input = new StreamReader(fs))
                {
                    string line;
                    while ((line = input.ReadLine()) != null) {
                        Deserialized.Add(line.Split(separator));
                    }
                }
            }
            return DeserializeFromString(Deserialized);
        }

        private DataContext DeserializeFromString(List<string[]> deserialized)
        {
            DataContext result = new DataContext();
            Dictionary<int, object> refObjectsDict = new Dictionary<int, object>();
            foreach (string[] data in deserialized) {


                switch (data[0]) {
                    case "Zadanie1.Book":
                        Book book = new Book(data, refObjectsDict);
                        result.books.Add(book);
                        refObjectsDict.Add(int.Parse(data[1]), book);
                        break;
                    case "Zadanie1.BookState":
                        BookState bookState = new BookState(data, refObjectsDict);
                        result.bookStates.Add(bookState);
                        refObjectsDict.Add(int.Parse(data[1]), bookState);
                        break;
                    case "Zadanie1.Client":
                        Client client = new Client(data, refObjectsDict);
                        result.clients.Add(client);
                        refObjectsDict.Add(int.Parse(data[1]), client);
                        break;
                    case "Zadanie1.Sale":
                        Event sale = new Sale(data, refObjectsDict);
                        result.events.Add(sale);
                        refObjectsDict.Add(int.Parse(data[1]), sale);
                        break;
                    case "Zadanie1.Purchase":
                        Event purchase = new Purchase(data, refObjectsDict);
                        result.events.Add(purchase);
                        refObjectsDict.Add(int.Parse(data[1]), purchase);
                        break;
                }
            }
            return result;
        }

        private string SerializeToString(DataContext dataContext, ObjectIDGenerator gen)
        {
            StringBuilder result = new StringBuilder();
            foreach (ICSerializable book in dataContext.books) {
                result.Append(book.Serialize(gen, separator));
                result.Append("\n");
            }
            foreach (ICSerializable bookState in dataContext.bookStates) {
                result.Append(bookState.Serialize(gen, separator));
                result.Append("\n");
            }
            foreach (ICSerializable client in dataContext.clients)
            {
                result.Append(client.Serialize(gen, separator));
                result.Append("\n");
            }
            foreach (ICSerializable _event in dataContext.events) {
                result.Append(_event.Serialize(gen, separator));
                result.Append("\n");
            }
            return result.ToString();
        }
    }
}
