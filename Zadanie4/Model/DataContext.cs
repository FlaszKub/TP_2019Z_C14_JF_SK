using System.Data.Linq;
using System.Linq;

namespace Model
{
    public class DataContext : IDataContext<Product>
    {
        private readonly ProductionDataContext production;

        public DataContext()
        {
            this.production = new ProductionDataContext();
        }

        public IQueryable<Product> GetItems()
        {
            return production.GetTable<Product>();
        }

        public bool Add(Product item)
        {
            try
            {
                production.GetTable<Product>().InsertOnSubmit(item);
                production.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool Update(Product item)
        {
            try
            {
                Product productToUpdate = production.Products.Where(p => p.ProductID == item.ProductID).First();
                productToUpdate.Name = item.Name;
                productToUpdate.ProductNumber = item.ProductNumber;
                productToUpdate.Color = item.Color;
                productToUpdate.SafetyStockLevel = item.SafetyStockLevel;
                productToUpdate.ReorderPoint = item.ReorderPoint;
                productToUpdate.StandardCost = item.StandardCost;
                productToUpdate.ListPrice = item.ListPrice;
                productToUpdate.Size = item.Size;
                productToUpdate.SizeUnitMeasureCode = item.SizeUnitMeasureCode;
                productToUpdate.WeightUnitMeasureCode = item.WeightUnitMeasureCode;
                productToUpdate.Weight = item.Weight;
                productToUpdate.DaysToManufacture = item.DaysToManufacture;
                productToUpdate.ProductLine = item.ProductLine;
                productToUpdate.Class = item.Class;
                productToUpdate.Style = item.Style;
                productToUpdate.ProductSubcategoryID = item.ProductSubcategoryID;
                productToUpdate.SellStartDate = item.SellStartDate;
                productToUpdate.ProductModelID = item.ProductModelID;
                productToUpdate.SellStartDate = item.SellStartDate;
                productToUpdate.SellEndDate = item.SellEndDate;
                productToUpdate.DiscontinuedDate = item.DiscontinuedDate;
                productToUpdate.ModifiedDate = item.ModifiedDate;
                production.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Delete(Product item)
        {
            try
            {
                production.GetTable<Product>().DeleteOnSubmit(item);
                production.SubmitChanges(ConflictMode.ContinueOnConflict);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Product Get(int id)
        {
            IQueryable<Product> products = (from product in production.Products
                                            where product.ProductID == id
                                            select product);
            if (products.Count() != 0)
            {
                return products.First();
            }
            else
            {
                return null;
            }
        }

    }
}
