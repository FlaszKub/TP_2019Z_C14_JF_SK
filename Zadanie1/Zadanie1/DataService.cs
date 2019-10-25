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
