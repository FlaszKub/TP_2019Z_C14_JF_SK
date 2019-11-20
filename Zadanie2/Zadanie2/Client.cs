using System.Collections.Generic;
using System.Runtime.Serialization;
using Zadanie2;

namespace Zadanie1
{
    public class Client : ICSerializable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }

        Client() {}
        public Client(string[] data, Dictionary<int, object> refObjectsDict)
        {
            FirstName = data[2];
            LastName = data[3];
            Id = data[4];
        }

        public Client(string firstName, string lastName, string id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName + " " + this.Id;
        }

        public override bool Equals(object obj)
        {
            return obj is Client client &&
                   FirstName == client.FirstName &&
                   LastName == client.LastName &&
                   Id == client.Id;
        }

        public override int GetHashCode()
        {
            int hashCode = 1258739292;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            return hashCode;
        }

        string ICSerializable.Serialize(ObjectIDGenerator gen, char separator)
        {
            string result = "";
            result += GetType().FullName + separator;
            result += gen.GetId(this, out bool firstTime).ToString() + separator;
            result += FirstName + separator;
            result += LastName + separator;
            result += Id.ToString() + separator;
            return result;
        }

        void ICSerializable.Deserialize(string[] data, Dictionary<int, object> refObjectsDict)
        {
            FirstName = data[2];
            LastName = data[3];
            Id = data[4];
        }
    }
}
