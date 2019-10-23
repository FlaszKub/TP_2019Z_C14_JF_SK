using System;
using System.Collections.Generic;

namespace Zadanie1
{
    public class BookState
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public float NetPrice { get; set; }
        public int Tax { get; set; }
        public string Id { get; set; }

        public BookState(Book book, int quantity, float netPrice, int tax, string id)
        {
            this.Book = book;
            this.NetPrice = netPrice;
            this.Tax = tax;
            this.Id = id;
            this.Quantity = quantity;  
        }

        public override bool Equals(object obj)
        {
            var state = obj as BookState;
            return state != null &&
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
    }
}
