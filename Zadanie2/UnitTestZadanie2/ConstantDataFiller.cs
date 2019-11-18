using System;
using Zadanie1;

namespace UnitTestZadanie2
{
    public class ConstantDataFiller
    {
        public static DataContext Fill()
        {
            DataContext context = new DataContext();
            context.clients.Add(new Client("John", "Hancock", "216834"));
            context.clients.Add(new Client("Holy", "Hancock", "215912"));
            context.clients.Add(new Client("John", "Smith", "217632"));
            context.clients.Add(new Client("Holy", "Smith", "216143"));

            context.books.Add(new Book("Michelle Obama", "Becoming", 686));
            context.books.Add(new Book("Tara Westover", "Tara Westover", 524));
            context.books.Add(new Book("Mark R. Levin", "Unfreedom of the Press", 125));
            context.books.Add(new Book("Jake Richards", "Backwoods Witchcraft", 666));

            context.bookStates.Add(new BookState(context.books[0], 10, 27.59f, 23, "XRA"));
            context.bookStates.Add(new BookState(context.books[1], 5, 30.49f, 23, "35D"));
            context.bookStates.Add(new BookState(context.books[2], 10, 39.99f, 23, "45Z"));
            context.bookStates.Add(new BookState(context.books[3], 10, 21.99f, 23, "15T"));

            context.events.Add(new Purchase(context.clients[0], context.bookStates[0], new DateTime(2019, 10, 15), 10));
            context.events.Add(new Purchase(context.clients[1], context.bookStates[1], new DateTime(2019, 10, 12), 8));
            context.events.Add(new Purchase(context.clients[0], context.bookStates[2], new DateTime(2019, 10, 11), 7));
            context.events.Add(new Purchase(context.clients[1], context.bookStates[3], new DateTime(2019, 10, 9), 6));

            context.events.Add(new Sale(context.clients[2], context.bookStates[1], new DateTime(2019, 10, 21), 1));
            context.events.Add(new Sale(context.clients[3], context.bookStates[0], new DateTime(2019, 10, 1), 4));
            context.events.Add(new Sale(context.clients[0], context.bookStates[3], new DateTime(2019, 10, 5), 1));
            context.events.Add(new Sale(context.clients[2], context.bookStates[3], new DateTime(2019, 10, 7), 2));

            return context;
        }
    }
}

