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

        public static List<Product> GetProductsWithoutCategoryLambda(this List<Product> products)
        {
            return products.Where(p => p.ProductSubcategory == null).ToList();
        }

        public static List<Product> GetProductsAsPage(this List<Product> products, int pageNumber, int productsNumber)
        {
            return products.Skip(productsNumber * (pageNumber - 1)).Take(productsNumber).ToList();
        }

        public static string GetVendorProductListQuery(this List<Product> products, List<ProductVendor> vendors)
        {
            string result = "";
            var answer = (from product in products
                          from productVendor in vendors
                          where product.ProductID.Equals(productVendor.ProductID)
                          select new { productName = product.Name, productVendorName = productVendor.Vendor.Name }).ToList();
            int indexLastElement = answer.Count - 1;
            for (int i = 0; i < answer.Count; i++)
            {
                if (i == indexLastElement)
                {
                    result += answer[i].productName + " - " + answer[i].productVendorName;
                }else
                {
                    result += answer[i].productName + " - " + answer[i].productVendorName + "\n";
                }
            }
            return result;
        }

        public static string GetVendorProductListLambda(this List<Product> products, List<ProductVendor> vendors)
        {
            string result = "";
            var answer = products.Join(vendors, product => product.ProductID, vendor => vendor.ProductID, (product, vendor) => new { productName = product.Name, productVendorName = vendor.Vendor.Name }).ToList();
            int indexLastElement = answer.Count - 1;

            for (int i = 0; i < answer.Count; i++)
            {
                if (i == indexLastElement)
                {
                    result += answer[i].productName + " - " + answer[i].productVendorName;
                }
                else
                {
                    result += answer[i].productName + " - " + answer[i].productVendorName + "\n";
                }
            }
            return result;

        }
    }

}

