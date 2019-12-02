using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public static class QueriesClass
    {
        
        public static List<Product> GetProductsByName(string namePart)
        {
            ProductionDataContext dataContext = new ProductionDataContext();
            IQueryable<Product> lista = from product in dataContext.Products
                                         where product.Name.Contains(namePart)
                                         select product;


            return lista.ToList<Product>();
        }
    }
}
