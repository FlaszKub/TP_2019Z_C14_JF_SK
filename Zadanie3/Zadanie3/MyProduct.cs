using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class MyProduct
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public EntitySet<ProductReview> ProductReviews { get; set; }
        public ProductSubcategory ProductSubcategory { get; set; }

        public MyProduct(Product product)
        {
            this.ProductID = product.ProductID;
            this.Name = product.Name;
            this.ProductNumber = product.ProductNumber;
            this.ProductReviews = product.ProductReviews;
            this.ProductSubcategory = product.ProductSubcategory;
        }
    }
}
