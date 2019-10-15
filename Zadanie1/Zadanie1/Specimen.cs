using System;

namespace Zadanie1
{
    public class Specimen
    {
        public Book Book { get; set; }
        public DateTimeOffset DateOfPurchase { get; set; }
        public float NetPrice { get; set; }
        public int Tax { get; set; }
        public string Id { get; set; }

        public Specimen(Book book, DateTimeOffset dateOfPurchase, float netPrice, int tax, string id)
        {
            this.Book = book;
            this.DateOfPurchase = dateOfPurchase;
            this.NetPrice = netPrice;
            this.Tax = tax;
            this.Id = id;
        }
    }
}
