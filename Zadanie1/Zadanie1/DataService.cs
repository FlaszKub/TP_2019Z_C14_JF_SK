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
        public IEnumerable<Book> GetAllBooks()
        {
            return dataRepository.GetAllBooks();
        }
        public IEnumerable<Client> GetAllClients()
        {
            return dataRepository.GetAllClients();
        }
        #endregion

        #region DisplayAsString
        public string DisplayClient(IEnumerable<Client> positions)
        {
            string result = "";
            foreach (Client position in positions)
            {
                result += position.ToString() + "|";
            }
            return result;
        }
        public string DisplayBook(IEnumerable<Book> positions)
        {
            string result = "";
            foreach (Book position in positions)
            {
                result += position.ToString() + "|";
            }
            return result;
        }
        public string DisplayBookState(IEnumerable<BookState> positions)
        {
            string result = "BookState";
            foreach (BookState position in positions)
            {
                result += position.ToString() + "|";
            }
            return result;
        }
        public string DisplayEvent(IEnumerable<Event> positions)
        {
            string result = "BookState";
            foreach (Event position in positions)
            {
                result += position.ToString() + "|";
            }
            return result;
        }
        #endregion

        public  IEnumerable<Event> GetEventsForClient(Client client)
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
    }
}
