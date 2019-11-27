using System;
using System.Collections.Generic;

namespace Zadanie1
{
    public class Sale : Event
    {
        public Sale(Client client, BookState bookState, DateTimeOffset date, int quantity) : base(client, bookState, date, quantity) { }
    }
}
