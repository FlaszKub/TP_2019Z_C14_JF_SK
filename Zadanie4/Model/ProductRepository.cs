using System.Linq;

namespace Model
{
    public class ProductRepository : IRepository<Product>
    {
        private IDataContext<Product> productsDataContext;

        public ProductRepository(IDataContext<Product> dataContext)
        {
            productsDataContext = dataContext;
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
    }
}
