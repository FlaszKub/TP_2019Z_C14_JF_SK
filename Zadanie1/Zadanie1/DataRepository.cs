

using System.Collections.Generic;

namespace Zadanie1
{
    public class DataRepository
    {
        private DataContext dataContext;
        private IDataFiller filler;
        public DataRepository(DataContext dataContext, IDataFiller filler)
        {
            this.dataContext = dataContext;
            this.filler = filler;
            filler.Fill(dataContext);
        }

        // C. R. U. D.

        #region Clients

        public void AddClient(Client client)
        {
            dataContext.clients.Add(client);
        }

        public Client GetClient(string id)
        {
            foreach (Client client in dataContext.clients)
            {
                if (client.Id == id)
                {
                    return client;
                }
            }
            return null;
        }

        public IEnumerable<Client> GetAllClients() {
            return dataContext.clients;
        }

        public void DeleteClient(string id) {
            foreach (Client client in dataContext.clients)
            {
                if (client.Id == id)
                {
                    dataContext.clients.Remove(client);
                    break;
                }
            }
        }

        public void DeleteClient(Client client) {
            dataContext.clients.Remove(client);
        }
        #endregion

        #region Books
        public void AddBook(Book book)
        {
            dataContext.books.Add(book.KeyNumber, book);
        }

        public Book GetBook(int key)
        {
            return dataContext.books[key];
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return dataContext.books.Values;
        }

        public void DeleteBook(int key)
        {
            dataContext.books.Remove(key);
        }
        #endregion

        #region BookStates
        public void AddBookState(BookState bookState)
        {
            dataContext.bookStates.Add(bookState);
        }

        public BookState GetBookState(string id)
        {
            foreach (BookState bookState in dataContext.bookStates)
            {
                if (bookState.Id == id)
                {
                    return bookState;
                }
            }
            return null;
        }

        public IEnumerable<BookState> GetAllBookStates()
        {
            return dataContext.bookStates;
        }

        public void DeleteBookState(string id)
        {
            foreach (BookState bookState in dataContext.bookStates)
            {
                if (bookState.Id == id)
                {
                    dataContext.bookStates.Remove(bookState);
                    break;
                }
            }
        }

        public void DeleteBookState(BookState bookState)
        {
            dataContext.bookStates.Remove(bookState);
        }
        #endregion

        #region Events
        public void AddEvent(Event _event) {
            dataContext.events.Add(_event);
        }

        public Event GetEvent(int id)
        {
            return dataContext.events[id];
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return dataContext.events;
        }

        public void DeleteEvent(Event _event)
        {
            dataContext.events.Remove(_event);
        }


        #endregion
    }
}
