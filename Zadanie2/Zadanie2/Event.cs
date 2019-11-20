using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Zadanie2;

namespace Zadanie1
{
    public abstract class Event : ICSerializable
    {
        public BookState BookState { get; set; }
        public Client Client { get; set; }
        public DateTimeOffset Date { get; set; }
        public int Quantity { get; set; }

        public Event() {}

        public Event(string[] data, Dictionary<int, object> refObjectsDict)
        {
            BookState = (BookState)refObjectsDict[int.Parse(data[2])];
            Client = (Client)refObjectsDict[int.Parse(data[3])];
            Date = DateTimeOffset.Parse(data[4]);
            Quantity = int.Parse(data[5]);
        }

        public Event(Client client, BookState bookState, DateTimeOffset date, int quantity)
        {
            this.Client = client;
            this.BookState = bookState;
            this.Date = date;
            this.Quantity = quantity;
        }

        public override string ToString()
        {
            return "BookState{" + this.BookState + "} " + "Client{" + this.Client + "} " + this.Date + " " + this.Quantity + " ";
        }

        public override bool Equals(object obj)
        {
            return obj is Event _event &&
                   EqualityComparer<BookState>.Default.Equals(BookState, _event.BookState) &&
                   EqualityComparer<Client>.Default.Equals(Client, _event.Client) &&
                   Date.Equals(_event.Date) &&
                   Quantity == _event.Quantity;
        }

        public override int GetHashCode()
        {
            int hashCode = 1248127326;
            hashCode = hashCode * -1521134295 + EqualityComparer<BookState>.Default.GetHashCode(BookState);
            hashCode = hashCode * -1521134295 + EqualityComparer<Client>.Default.GetHashCode(Client);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTimeOffset>.Default.GetHashCode(Date);
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            return hashCode;
        }

        string ICSerializable.Serialize(ObjectIDGenerator gen, char separator)
        {
            string result = "";
            result += GetType().FullName + separator;
            result += gen.GetId(this, out bool firstTime).ToString() + separator;
            result += gen.GetId(BookState, out firstTime).ToString() + separator;
            result += gen.GetId(Client, out firstTime).ToString() + separator;
            result += Date.ToString() + separator;
            result += Quantity.ToString() + separator;
            return result;
        }

        void ICSerializable.Deserialize(string[] data, Dictionary<int, object> refObjectsDict)
        {
            BookState = (BookState)refObjectsDict[int.Parse(data[2])];
            Client = (Client)refObjectsDict[int.Parse(data[3])];
            Date = DateTimeOffset.Parse(data[4]);
            Quantity = int.Parse(data[5]);
        }
    }
}
