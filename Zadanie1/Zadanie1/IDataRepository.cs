using System.Collections.Generic;

namespace Zadanie1
{
    public interface IDataRepository
    {
        #region Clients
        void AddClient(Client client);
        Client GetClient(int index);
        IEnumerable<Client> GetAllClients();
        void DeleteClient(int index);
        void DeleteClient(Client client);
        #endregion

        #region Books
        void AddBook(Book book);
        Book GetBook(int key);
        IEnumerable<Book> GetAllBooks();
        void DeleteBook(int key);
        #endregion

        #region BookStates
        void AddBookState(BookState bookState);
        BookState GetBookState(int index);
        IEnumerable<BookState> GetAllBookStates();
        void DeleteBookState(int index);
        void DeleteBookState(BookState bookState);

        #endregion

        #region Events
        void AddEvent(Event _event);
        Event GetEvent(int index);
        IEnumerable<Event> GetAllEvents();
        void DeleteEvent(Event _event);
        void DeleteEvent(int index);
        #endregion
    }
}
