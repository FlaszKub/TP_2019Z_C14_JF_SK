using System;
using System.Collections.Generic;

namespace Zadanie1
{
    public class Purchase : Event
    {
        public Purchase() : base() { }
        public Purchase(string[] data, Dictionary<int, object> refObjectsDict) : base(data, refObjectsDict) { }
        public Purchase(Client client, BookState bookState, DateTimeOffset date, int quantity) : base(client, bookState, date, quantity) { }
    }
}
