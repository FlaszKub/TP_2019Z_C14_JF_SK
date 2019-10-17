using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Zadanie1
{
    public class DataContext
    {
        public List<Client> clients = new List<Client>();
        public Dictionary<int, Book> books = new Dictionary<int, Book>();
        public ObservableCollection<Event> events = new ObservableCollection<Event>();
        public List<BookState> bookStates = new List<BookState>();
    }
}
