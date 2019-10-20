using System;
using System.Collections.Generic;

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

        public override bool Equals(object obj)
        {
            var @event = obj as Event;
            return @event != null &&
                   EqualityComparer<BookState>.Default.Equals(BookState, @event.BookState) &&
                   EqualityComparer<Client>.Default.Equals(Client, @event.Client) &&
                   Date.Equals(@event.Date) &&
                   Quantity == @event.Quantity &&
                   IsPurchase == @event.IsPurchase;
        }

        public override int GetHashCode()
        {
            var hashCode = 1248127326;
            hashCode = hashCode * -1521134295 + EqualityComparer<BookState>.Default.GetHashCode(BookState);
            hashCode = hashCode * -1521134295 + EqualityComparer<Client>.Default.GetHashCode(Client);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTimeOffset>.Default.GetHashCode(Date);
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            hashCode = hashCode * -1521134295 + IsPurchase.GetHashCode();
            return hashCode;
        }
    }
}
