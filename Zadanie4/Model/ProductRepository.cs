using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class ProductRepository : IRepository<Product>
    {
        private IDataContext<Product> productsDataContext;

        public ProductRepository()
        {
            productsDataContext = new DataContext();
        }

        public bool Add(Product item)
        {
            return productsDataContext.Add(item);
        }

        public bool Delete(Product item)
        {
            return productsDataContext.Delete(item);
        }

        public Product Get(int id)
        {
            return productsDataContext.Get(id);
        }

        public IQueryable<Product> GetAll()
        {
            return productsDataContext.GetItems();
        }

        public bool Update(Product item)
        {
            return productsDataContext.Update(item);
        }

        public List<Product> GetAllProduct()
        {
            List<Product> result = (from product in GetAll()
                                    select product).ToList();
            return result;
        }
    }
}
