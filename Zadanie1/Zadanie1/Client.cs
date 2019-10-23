using System.Collections.Generic;

namespace Zadanie1
{
    public class Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
   
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
    }
}
