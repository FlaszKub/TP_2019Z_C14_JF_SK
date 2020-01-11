using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class MainViewModel
    {
        private List<Product> products;
        #region Property
        public List<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
            }
        }
        public ProductRepository ProductRepository { get; set; }

        public IWindow MainWindow { get; set; }
        #endregion

        public MainViewModel()
        {
            ProductRepository = new ProductRepository();
            products = ProductRepository.GetAllProduct();
        }
    }
}
