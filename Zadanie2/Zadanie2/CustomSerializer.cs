using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Zadanie1;

namespace Zadanie2
{
    class CustomSerializer
    {
        string Serialized;
        Dictionary<int, object> refObjectsDict;
        List<string> Deserialized = new List<string>();
        public CustomSerializer(){
            
        }
        public void Serialize(DataContext dataContext, String path) {
            ObjectIDGenerator gen = new ObjectIDGenerator();
            Serialized = serializeToString(dataContext, gen);
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine(Serialized);
                }
            }
        }

        public DataContext Deserialize(String path)
        {
            DataContext context = new DataContext();

            return context;
        }

        private string serializeToString(DataContext dataContext, ObjectIDGenerator gen)
        {
            String result = "";
            foreach (ICSerializable book in dataContext.books) {
                result += book.Serialize(gen) + "\n";
            }
            foreach (ICSerializable bookState in dataContext.bookStates) {
                result += bookState.Serialize(gen) + "\n";
            }
            foreach (ICSerializable client in dataContext.clients)
            {
                result += client.Serialize(gen) + "\n";
            }
            foreach (ICSerializable _event in dataContext.events) {
                result += _event.Serialize(gen) + "\n";
            }
            return result;
        }
    }
}
