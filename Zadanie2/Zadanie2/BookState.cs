using System.Collections.Generic;
using System.Runtime.Serialization;
using Zadanie2;

namespace Zadanie1
{
    public class BookState : ICSerializable
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public float NetPrice { get; set; }
        public int Tax { get; set; }
        public string Id { get; set; }

        public BookState() { }

        public BookState(Book book, int quantity, float netPrice, int tax, string id)
        {
            this.Book = book;
            this.NetPrice = netPrice;
            this.Tax = tax;
            this.Id = id;
            this.Quantity = quantity;
        }

        public override string ToString()
        {
            return "Book{" + this.Book + "} " + this.Quantity + " " + this.NetPrice + " " + this.Tax + " " + this.Id;
        }

        public override bool Equals(object obj)
        {
            return obj is BookState state &&
                   EqualityComparer<Book>.Default.Equals(Book, state.Book) &&
                   Quantity == state.Quantity &&
                   NetPrice == state.NetPrice &&
                   Tax == state.Tax &&
                   Id == state.Id;
        }

        public override int GetHashCode()
        {
            var hashCode = 677800335;
            hashCode = hashCode * -1521134295 + EqualityComparer<Book>.Default.GetHashCode(Book);
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            hashCode = hashCode * -1521134295 + NetPrice.GetHashCode();
            hashCode = hashCode * -1521134295 + Tax.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            return hashCode;
        }

        string ICSerializable.Serialize(ObjectIDGenerator gen)
        {
            string result = "";
            result += GetType().FullName + ',';
            result += gen.GetId(this, out bool firstTime).ToString();
            result += gen.GetId(Book, out firstTime).ToString();
            result += Quantity + ',';
            result += NetPrice + ',';
            result += Tax + ',';
            result += Id + ',';
            return result;
            
        }

        void ICSerializable.Deserialize(string[] data, Dictionary<int, object> refObjectsDict)
        {
            Book = (Book)refObjectsDict[int.Parse(data[2])];
            Quantity = int.Parse(data[3]);
            NetPrice = float.Parse(data[4]);
            Tax = int.Parse(data[5]);
            Id = data[6];

        }
    }
}
