using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class ProductRepository : IRepository<Product>
    {
        private IDataContext<Product> productsDataContext;
        public delegate void Handler();
        public event Handler ChangeInCollection;

        public ProductRepository()
        {
            productsDataContext = new DataContext();
        }

        public bool Add(Product item)
        {
            return productsDataContext.Add(item);
        }

        public bool Delete(int Id)
        {
            bool result = productsDataContext.Delete(Get(Id));
            ChangeInCollection?.Invoke();
            return result;
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
