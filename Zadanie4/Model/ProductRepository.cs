using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
