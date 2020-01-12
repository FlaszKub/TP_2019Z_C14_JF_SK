using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Model;

namespace ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<Product> products;
        private Product _product;
        #region Property
        public List<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                NotifyPropertyChanged("Products");
            }
        }
        public Product Product
        {
            get { return _product; }
            set
            {
                _product = value;
            }
        }
        public ProductRepository ProductRepository { get; set; }
        public ICommand DeleteCommand { get; private set; }

        public IWindow MainWindow { get; set; }
        #endregion

        public MainViewModel()
        {

            ProductRepository = new ProductRepository();
            products = ProductRepository.GetAllProduct();
            DeleteCommand = new OwnCommand(DeleteProduct);
            ProductRepository.ChangeInCollection += OnProductsChanged;
        }

        private void DeleteProduct()
        {
            if(Product is null || Product.ProductID <= 0)
            {
                MainWindow.ShowPopup("Select a product");
            } else
            {
                ProductRepository.Delete(Product.ProductID);
            }
        }


        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public void OnProductsChanged()
        {
            this.Products = ProductRepository.GetAllProduct();
        }

    }
}
