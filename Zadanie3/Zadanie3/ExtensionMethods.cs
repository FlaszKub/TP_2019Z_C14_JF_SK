using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public static class ExtensionMethods
    {

        public static List<Product> GetProductsWithoutCategoryQuery(this List<Product> products)
        {
            List<Product> answer = (from product in products
                                    where product.ProductSubcategory == null
                                    select product).ToList();
            return answer;
        }

        public static List<Product> GetProductsWithoutCategory(this List<Product> products)
        {
            return products.Where(p => p.ProductSubcategory == null).ToList();
        }


    }
}
