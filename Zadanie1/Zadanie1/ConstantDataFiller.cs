using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class ConstantDataFiller : IDataFiller
    {
        public void Fill(DataContext context)
        {
            context.clients.Add(new Client("John", "Hancock", "216834"));
            context.clients.Add(new Client("Holy", "Hancock", "215912"));
            context.clients.Add(new Client("John", "Smith", "217632"));
            context.clients.Add(new Client("Holy", "Smith", "216143"));

            context.books.Add(686, new Book("Michelle Obama", "Becoming", 686));
            context.books.Add(524, new Book("Tara Westover", "Tara Westover", 524));
            context.books.Add(125, new Book("Mark R. Levin", "Unfreedom of the Press", 125));
            context.books.Add(666, new Book("Jake Richards", "Backwoods Witchcraft", 666));

            context.bookStates.Add(new BookState(context.books[686], 10, 27.59f, 23, "XRA"));
            context.bookStates.Add(new BookState(context.books[524], 5, 30.49f, 23, "35D"));
            context.bookStates.Add(new BookState(context.books[125], 10, 39.99f, 23, "45Z"));
            context.bookStates.Add(new BookState(context.books[666], 10, 21.99f, 23, "15T"));

            context.events.Add(new Event(context.clients[0], context.bookStates[0], DateTimeOffset.Now, 10, true));
            context.events.Add(new Event(context.clients[1], context.bookStates[1], DateTimeOffset.Now, 8, true));
            context.events.Add(new Event(context.clients[0], context.bookStates[2], DateTimeOffset.Now, 7, true));
            context.events.Add(new Event(context.clients[1], context.bookStates[3], DateTimeOffset.Now, 6, true));

            context.events.Add(new Event(context.clients[2], context.bookStates[1], DateTimeOffset.Now, 1, false));
            context.events.Add(new Event(context.clients[3], context.bookStates[0], DateTimeOffset.Now, 4, false));
            context.events.Add(new Event(context.clients[0], context.bookStates[3], DateTimeOffset.Now, 1, false));
            context.events.Add(new Event(context.clients[2], context.bookStates[3], DateTimeOffset.Now, 2, false));
        }
    }
}
