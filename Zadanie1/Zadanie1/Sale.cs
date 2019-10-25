using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class Sale : Event
    {
        public Sale(Client client, BookState bookState, DateTimeOffset date, int quantity) : base(client, bookState, date, quantity) { }
    }
}
