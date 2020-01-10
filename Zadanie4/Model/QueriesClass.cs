using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace Zadanie3
{
    public static class QueriesClass
    {

        public static List<Product> GetProductsByName(string namePart)
        {
            ProductionDataContext dataContext = new ProductionDataContext();
            return new List<Product>(from product in dataContext.Products
                                     where product.Name.Contains(namePart)
                                     orderby product.ProductID descending
                                     select product);

        }

        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            ProductionDataContext db = new ProductionDataContext();
            return new List<Product>(from product in db.Products
                                     join productVendor in db.ProductVendors on product.ProductID equals productVendor.ProductID
                                     where productVendor.Vendor.Name == vendorName
                                     orderby product.ProductID descending
                                     select product);
        }

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            ProductionDataContext db = new ProductionDataContext();
            return new List<string>(from product in db.Products
                                    join productVendor in db.ProductVendors on product.ProductID equals productVendor.ProductID
                                    where productVendor.Vendor.Name == vendorName
                                    orderby product.ProductID descending
                                    select product.Name);
        }

        public static string GetProductVendorByProductName(string productName)
        {
            ProductionDataContext db = new ProductionDataContext();
            return (from product in db.Products
                    join productVendor in db.ProductVendors on product.ProductID equals productVendor.ProductID
                    where product.Name == productName
                    select productVendor.Vendor.Name).First();

        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            ProductionDataContext db = new ProductionDataContext();
            return new List<Product>(from product in db.Products
                                     where product.ProductReviews.Count == howManyReviews
                                     select product
                                  );

        }

        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            ProductionDataContext db = new ProductionDataContext();
            return new List<Product>((from  review in db.ProductReviews                                     
                                      orderby review.ReviewDate descending
                                      group review.Product by review.ProductID into g
                                      select g.First()).Take(howManyProducts)
                                    );
        }

        public static List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            ProductionDataContext db = new ProductionDataContext();
            return new List<Product>((from product in db.Products
                                      where product.ProductSubcategory.ProductCategory.Name == categoryName
                                      orderby product.Name
                                      select product).Take(n)
                                       );
        }

        public static int GetTotalStandardCostByCategory(ProductCategory category)
        {
            ProductionDataContext db = new ProductionDataContext();
            return (int)(from product in db.Products
                         where product.ProductSubcategory.ProductCategory.Name == category.Name
                         select product.StandardCost).Sum();
        }
    }
}
