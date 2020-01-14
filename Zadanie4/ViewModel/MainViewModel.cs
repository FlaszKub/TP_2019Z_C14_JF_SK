using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Service;


namespace ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<Product> products;
        private Product _product;
        private bool _visibility;
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

        public ICommand EditCommand { get; private set; }

        public IWindow MainWindow { get; set; }

        public List<string> Colors { get; set; }
        public List<string> SizesUnits { get; set; }
        public List<string> WeightUnits { get; set; }
        public List<string> ProductLines { get; set; }
        public List<string> Classes { get; set; }
        public List<string> Styles { get; set; }
        public List<string> ProductSubCategories { get; set; }
        public List<string> ModelIds { get; set; }
        #endregion

        public bool Visibility
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
                NotifyPropertyChanged("Visibility");
            }
        }

        public string ProductName { get; set; }
        public string ProductNumber { get; set; }
        public bool MakeFlag { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public string Color { get; set; } = null;
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; } = null;
        public string SizeUnitMeasureCode { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public decimal? Weight { get; set; }
        public int DaysToManufacture { get; set; }
        public string ProductLine { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public string ProductSubcategoryID { get; set; }
        public string ModelId { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime SellStartDate { get; set; }






        public MainViewModel()
        {
            ProductRepository = new ProductRepository();
            products = ProductRepository.GetAllProduct();
            DeleteCommand = new OwnCommand(DeleteProduct);
            EditCommand = new OwnCommand(EditProduct);
            ProductRepository.ChangeInCollection += OnProductsChanged;
            _visibility = false;
            InitList();
        }

        private void InitList()
        {
            this.Colors = this.ProductRepository.GetColors();
            this.SizesUnits = this.ProductRepository.GetSizesUnits();
            this.WeightUnits = this.ProductRepository.GetWeightUnits();
            this.ProductLines = this.ProductRepository.GetProductLines();
            this.Classes = this.ProductRepository.GetProductLines();
            this.Styles = this.ProductRepository.GetStyles();
            this.ProductSubCategories = this.ProductRepository.GetProductSubCategories();
            this.ModelIds = this.ProductRepository.GetModelIds();
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

        private void EditProduct()
        {
            if (Product is null || Product.ProductID <= 0)
            {
                MainWindow.ShowPopup("Select a product");
            }
            else
            {
                this.Visibility = true;
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
