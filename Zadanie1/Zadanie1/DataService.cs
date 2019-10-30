using System;
using System.Collections.Generic;

namespace Zadanie1
{
    public class DataService
    {
        private IDataRepository dataRepository;

        public DataService(IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        #region GetAll
        public IEnumerable<Book> GetAllBooks() => dataRepository.GetAllBooks();
        public IEnumerable<Client> GetAllClients() => dataRepository.GetAllClients();
        public IEnumerable<Event> GetAllEvents() => dataRepository.GetAllEvents();
        public IEnumerable<BookState> GetAllBookStates() => dataRepository.GetAllBookStates();
        #endregion

        #region Add
        public void AddClient(Client client) => dataRepository.AddClient(client);
        public void AddBook(Book book) => dataRepository.AddBook(book);
        public void AddBookState(BookState bookState) => dataRepository.AddBookState(bookState);
        #endregion

        #region Delete
        public void DeleteEvent(Event even) => dataRepository.DeleteEvent(even);
        public void DeleteClient(Client client) => dataRepository.DeleteClient(client);
        public void DeleteBook(int bookKey) => dataRepository.DeleteBook(bookKey);
        public void DeleteBookState(BookState bookState) => dataRepository.DeleteBookState(bookState);
        #endregion

        public IEnumerable<Event> GetEventsForClient(Client client)
        {
            List<Event>  result = new List<Event>();
            foreach(Event _event in dataRepository.GetAllEvents())
            {
                if (_event.Client.Equals(client))
                    result.Add(_event);
            }
            return result;
        }

        public IEnumerable<Event> GetEventsBetweenDates(DateTimeOffset from, DateTimeOffset to)
        {
            List<Event> result = new List<Event>();
            foreach (Event _event in dataRepository.GetAllEvents())
            {
                if (_event.Date > from && _event.Date < to)
                    result.Add(_event);
            }
            return result;
        }

        public IEnumerable<Event> GetEventsForBook(Book book)
        {
            List<Event> result = new List<Event>();
            foreach (Event _event in dataRepository.GetAllEvents())
            {
                if (_event.BookState.Book.Equals(book))
                    result.Add(_event);
            }
            return result;
        }

        public void SellBooks(Client client, BookState bookState, int quantity) {
            Event sell = new Sale(client, bookState, DateTimeOffset.Now, quantity);
            dataRepository.AddEvent(sell);
        }

        public void PurchaseBooks(Client client, BookState bookState, int quantity)
        {
            Event purch = new Purchase(client, bookState, DateTimeOffset.Now, quantity);
            dataRepository.AddEvent(purch);
        }

        public IEnumerable<Event> GetAllPurchases() {
            List<Event> result = new List<Event>();
            foreach (Event _event in dataRepository.GetAllEvents())
            {
                if (_event is Purchase)
                    result.Add(_event);
            }
            return result;

        }

        public IEnumerable<Client> GetClientsForBook(Book book)
        {
            List<Client> result = new List<Client>();
            foreach (Event _event in dataRepository.GetAllEvents())
            {
                if (_event is Sale && _event.BookState.Book.Equals(book))
                    result.Add(_event.Client);
            }
            return result;

        }

    }
}
