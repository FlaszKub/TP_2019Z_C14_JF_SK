using System;
using System.Collections.Generic;

namespace Zadanie1
{
    public class Sale : Event
    {
        public Sale() : base() { }
        public Sale(string[] data, Dictionary<int, object> refObjectsDict) : base(data, refObjectsDict) { }
        public Sale(Client client, BookState bookState, DateTimeOffset date, int quantity) : base(client, bookState, date, quantity) { }
    }
}
