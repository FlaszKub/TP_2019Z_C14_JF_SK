using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Zadanie1
{
    public class DataContext
    {
        public List<Client> clients = new List<Client>();
        public List<Book> books = new List<Book>();
        public List<Event> events = new List<Event>();
        public List<BookState> bookStates = new List<BookState>();
    }
}
