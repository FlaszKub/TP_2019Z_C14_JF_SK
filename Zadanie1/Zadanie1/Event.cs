using System;

namespace Zadanie1
{
    public class Event
    {
        public BookState BookState { get; set; }
        public Client Client { get; set; }
        public DateTimeOffset Date { get; set; }
        public int Quantity { get; set; }
        public bool IsPurchase { get; set; }

        public Event(Client client, BookState bookState, DateTimeOffset date, int quantity, bool isPurchase)
        {
            this.Client = client;
            this.BookState = bookState;
            this.Date = date;
            this.Quantity = quantity;
            this.IsPurchase = isPurchase;
        }
    }
}
