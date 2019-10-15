using System;

namespace Zadanie1
{
    public class SaleEvent
    {
        public Specimen Specimen { get; set; }
        public Client Client { get; set; }
        public DateTimeOffset SaleDate { get; set; }

        public SaleEvent(Client client, Specimen specimen, DateTimeOffset saleDate)
        {
            this.Client = client;
            this.Specimen = specimen;
            this.SaleDate = saleDate;
        }
    }
}
