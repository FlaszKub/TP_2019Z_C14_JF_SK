using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;

namespace Service
{
    public class ProductRepository
    {
        private IDataContext<Product> productsDataContext;
        public delegate void Handler();
        public event Handler ChangeInCollection;

        public ProductRepository()
        {
            productsDataContext = new DataContext();
        }

        public void Add(Product item)
        {
            Task.Run(() =>
            {
                productsDataContext.Add(item);
                ChangeInCollection?.Invoke();
            });
        }

        public void Delete(int Id)
        {

            Task.Run(() =>
            {
                productsDataContext.Delete(Get(Id));
                ChangeInCollection?.Invoke();
            });

        }

        public Product Get(int id)
        {
            return productsDataContext.Get(id);
        }

        public IQueryable<Product> GetAll()
        {
            return productsDataContext.GetItems();
        }

        public void Update(Product item)
        {
            Task.Run(() =>
            {
                productsDataContext.Update(item);
            });
        }

        public List<Product> GetAllProduct()
        {
            List<Product> result = (from product in GetAll()
                                    select product).ToList();
            return result;
        }

        public List<Product> GetAllProducts()
        {
            return productsDataContext.GetItems().Where(product => !product.DiscontinuedDate.HasValue).ToList();
        }

        public List<string> GetColors()
        {
            return (from product in productsDataContext.GetItems()
                    select product.Color).Distinct().ToList();
        }

        public List<string> GetSizes()
        {
            List<string> answer = new List<string>();
            List<Product> products = productsDataContext.GetItems().GroupBy(x => x.Size).Select(g => g.First()).ToList();
            foreach (Product p in products)
            {
                answer.Add(p.Size);
            }
            return answer;
        }

        public List<string> GetSizesUnits()
        {
            return (from product in productsDataContext.GetItems()
                    where product.SizeUnitMeasureCode != null
                    select product.SizeUnitMeasureCode).Distinct().ToList();
        }

        public List<string> GetWeightUnits()
        {
            return (from product in productsDataContext.GetItems()
                    where product.WeightUnitMeasureCode != null
                    select product.WeightUnitMeasureCode).Distinct().ToList();
        }

        public List<string> GetProductLines()
        {
            List<string> answer = new List<string>();
                List<Product> products = productsDataContext.GetItems().GroupBy(x => x.ProductLine).Select(g => g.First()).ToList();
                foreach (Product p in products)
                {
                    answer.Add(p.ProductLine);
                }
            return answer;
        }

        public List<string> GetClasses()
        {
            return (from product in productsDataContext.GetItems()
                    where product.Class != null
                    select product.Class).Distinct().ToList();
        }

        public List<string> GetStyles()
        {
            return (from product in productsDataContext.GetItems()
                    where product.Style != null
                    select product.Style).Distinct().ToList();
        }

        public List<string> GetProductSubCategories()
        {
            return (from product in productsDataContext.GetItems()
                    where product.ProductSubcategory != null
                    select product.ProductSubcategory.Name).Distinct().ToList();
        }

        public List<string> GetModels()
        {
                return (from product in productsDataContext.GetItems()
                        where product.ProductModel != null
                        select product.ProductModel.Name).Distinct().ToList();

        }

        public ProductSubcategory GetProductSubcategoryForName(string Name)
        {
            return (from product in productsDataContext.GetItems()
                           where product.ProductSubcategory.Name == Name
                           select product.ProductSubcategory).First();
        }

        public ProductModel GetProductModelForName(string Name)
        { 
            return (from product in productsDataContext.GetItems()
                   where product.ProductModel.Name == Name
                   select product.ProductModel).First();
        }

        public string getSubcatergoryNameForID(int? id)
        {
            return (from product in productsDataContext.GetItems()
                    where product.ProductSubcategoryID == id
                    select product.ProductSubcategory.Name).First();
        }

        public string getModelNameForID(int? id)
        {
            return (from product in productsDataContext.GetItems()
                    where product.ProductModelID == id
                    select product.ProductModel.Name).First();
        }
    }
}

