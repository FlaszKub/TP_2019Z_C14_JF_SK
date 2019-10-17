using System;

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
    }
}
