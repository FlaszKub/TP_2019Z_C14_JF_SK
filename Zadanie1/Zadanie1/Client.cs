

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
    }
}
