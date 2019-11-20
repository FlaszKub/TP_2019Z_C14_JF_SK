using Newtonsoft.Json;
using System.IO;
using Zadanie1;




namespace Zadanie2
{
    public class JsonSerializer
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
            MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
            PreserveReferencesHandling = PreserveReferencesHandling.Objects
        };

        public void Serialize(DataContext context, string path)
        {
            string json = JsonConvert.SerializeObject(context, Formatting.Indented, settings);
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (BinaryWriter w = new BinaryWriter(fs))
                {
                    w.Write(json);
                }
            }
        }

        public DataContext DeserializeToDataContext(string path)
        {
            string json;
            DataContext context;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                using (BinaryReader r = new BinaryReader(fs))
                {
                    json = r.ReadString();
                    context = JsonConvert.DeserializeObject<DataContext>(json, settings);
                }
            }
            return context;
        }
    }
}
