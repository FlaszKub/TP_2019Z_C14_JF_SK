using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Zadanie1;

namespace UnitTestZadanie1
{
    public class DataRepository : IDataRepository
    {
        private DataContext dataContext;
        private IDataFiller filler;

        public event EventHandler EventAdded;
        public event EventHandler EventRemoved;

        public DataRepository(DataContext dataContext, IDataFiller filler)
        {
            this.dataContext = dataContext;
            this.dataContext.events.CollectionChanged += CollectionEventsChanged;
            this.filler = filler;
            filler.Fill(dataContext);
        }

        private void CollectionEventsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                EventAdded?.Invoke(this, e);
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                EventRemoved?.Invoke(this, e);
            }
        }

        // C. R. U. D.


        #region Clients

        public void AddClient(Client client)
        {
            if (!dataContext.clients.Contains(client))
            {
                dataContext.clients.Add(client);
            }
        }

        public Client GetClient(int index)
        {
            return dataContext.clients[index];
        }

        public IEnumerable<Client> GetAllClients()
        {
            return dataContext.clients;
        }

        public void DeleteClient(Client client)
        {
            if (dataContext.clients.Contains(client))
            {
                dataContext.clients.Remove(client);
            }
        }
        #endregion

        #region Books
        public void AddBook(Book book)
        {
            if (!dataContext.books.ContainsKey(book.KeyNumber))
            {
                dataContext.books.Add(book.KeyNumber, book);
            }
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
            this.AddBook(bookState.Book);
            dataContext.bookStates.Add(bookState);
        }

        public BookState GetBookState(int index)
        {
            return dataContext.bookStates[index];
        }

        public IEnumerable<BookState> GetAllBookStates()
        {
            return dataContext.bookStates;
        }

        public void DeleteBookState(BookState bookState)
        {
            if (dataContext.bookStates.Contains(bookState))
            {
                dataContext.bookStates.Remove(bookState);
            }
        }
        #endregion

        #region Events
        public void AddEvent(Event _event)
        {
            this.AddClient(_event.Client);
            this.AddBookState(_event.BookState);
            if (_event is Sale)
            {
                _event.BookState.Quantity = _event.BookState.Quantity - _event.Quantity;
                dataContext.events.Add(_event);
            }
            else if (_event is Purchase)
            {
                _event.BookState.Quantity = _event.BookState.Quantity + _event.Quantity;
                dataContext.events.Add(_event);
            }
        }

        public Event GetEvent(int index)
        {
            return dataContext.events[index];
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return dataContext.events;
        }

        public void DeleteEvent(Event _event)
        {
            if (dataContext.events.Contains(_event))
            {
                dataContext.events.Remove(_event);
            }
        }

        #endregion
    }
}
