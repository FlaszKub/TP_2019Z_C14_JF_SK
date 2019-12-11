using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class MyProductDataContext
    {
        public List<MyProduct> myProducts { get; private set; }

        public MyProductDataContext(List<MyProduct> products)
        {
            this.myProducts = products;
        }

        public List<MyProduct> GetMyProductsByName(string namePart)
        {
            return (from product in myProducts
                    where product.Name.ToLower().Contains(namePart.ToLower())
                    select product).ToList();
        }

        public List<MyProduct> GetNMyProductFromCategory(string categoryName, int n)
        {
            List<MyProduct> result = (from product in myProducts
                                      where product.ProductSubcategory != null && product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                                      select product).Take(n).ToList();
            return result;
        }

        public List<MyProduct> GetMyProductsWithNRecentReviews(int howManyReviews)
        {
            return new List<MyProduct>(from product in myProducts
                                     where product.ProductReviews.Count == howManyReviews
                                     select product
                                  );

        }

    }
}
