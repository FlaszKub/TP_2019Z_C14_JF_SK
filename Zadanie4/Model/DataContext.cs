using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;

namespace Data
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
                productToUpdate.Size = item.Size;
                productToUpdate.SizeUnitMeasureCode = item.SizeUnitMeasureCode;
                productToUpdate.WeightUnitMeasureCode = item.WeightUnitMeasureCode;
                productToUpdate.Weight = item.Weight;
                productToUpdate.DaysToManufacture = item.DaysToManufacture;
                productToUpdate.ProductLine = item.ProductLine;
                productToUpdate.Class = item.Class;
                productToUpdate.Style = item.Style;
                productToUpdate.ProductSubcategoryID = item.ProductSubcategoryID;
                productToUpdate.ProductModelID = item.ProductModelID;
                productToUpdate.SellStartDate = item.SellStartDate;
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
                production.Products.DeleteOnSubmit(item);
                production.SubmitChanges(ConflictMode.ContinueOnConflict);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
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

        public List<string> SelectColors()
        {
            List<string> answer = new List<string>();

            List<Product> products = production.Products.GroupBy(x => x.Color).Select(g => g.First()).ToList();
            foreach (Product p in products)
            {
                answer.Add(p.Color);
            }
            return answer;
        }

    }

}
