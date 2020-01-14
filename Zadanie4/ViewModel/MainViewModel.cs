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
        public List<string> Sizes { get; set; }
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

        #region private static data
        private string _productName;
        private string _productNumber;
        private string _color;
        private short _safetyStockLevel;
        private short _reorderPoint;
        private decimal _standardCost;
        private string _size;
        private string _sizeUnitMeasureCode;
        private string _weightUnitMeasureCode;
        private decimal? _weight;
        private int _daysToManufacture;
        private string _productLine;
        private string _class;
        private string _style;
        private string _productSubcategoryID;
        private string _modelId;
        private DateTime _sellStartDate;
        #endregion

        #region lala
        public string ProductName
        {
            get { return _productName; }
            set
            {
                _productName = value;
                NotifyPropertyChanged("ProductName");
            }
        }
        public string ProductNumber
        {
            get { return _productNumber; }
            set
            {
                _productNumber = value;
                NotifyPropertyChanged("ProductNumber");
            }
        }
        public string Color
        {
            get { return _color; }
            set
            {
                _color = value;
                NotifyPropertyChanged("Color");
            }
        }
        public short SafetyStockLevel
        {
            get { return _safetyStockLevel; }
            set
            {
                _safetyStockLevel = value;
                NotifyPropertyChanged("SafetyStockLevel");
            }
        }
        public short ReorderPoint
        {
            get { return _reorderPoint; }
            set
            {
                _reorderPoint = value;
                NotifyPropertyChanged("ReorderPoint");
            }
        }
        public decimal StandardCost
        {
            get { return _standardCost; }
            set
            {
                _standardCost = value;
                NotifyPropertyChanged("StandardCost");
            }
        }
        public string Size
        {
            get { return _size; }
            set
            {
                _size = value;
                NotifyPropertyChanged("Size");
            }
        }
        public string SizeUnitMeasureCode
        {
            get { return _sizeUnitMeasureCode; }
            set
            {
                _sizeUnitMeasureCode = value;
                NotifyPropertyChanged("SizeUnitMeasureCode");
            }
        }
        public string WeightUnitMeasureCode
        {
            get { return _weightUnitMeasureCode; }
            set
            {
                _weightUnitMeasureCode = value;
                NotifyPropertyChanged("WeightUnitMeasureCode");
            }
        }
        public decimal? Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                NotifyPropertyChanged("Weight");
            }
        }
        public int DaysToManufacture
        {
            get { return _daysToManufacture; }
            set
            {
                _daysToManufacture = value;
                NotifyPropertyChanged("DaysToManufacture");
            }
        }
        public string ProductLine
        {
            get { return _productLine; }
            set
            {
                _productLine = value;
                NotifyPropertyChanged("ProductLine");
            }
        }
        public string Class
        {
            get { return _class; }
            set
            {
                _class = value;
                NotifyPropertyChanged("Class");
            }
        }
        public string Style
        {
            get { return _style; }
            set
            {
                _style = value;
                NotifyPropertyChanged("Style");
            }
        }
        public string ProductSubcategoryID
        {
            get { return _productSubcategoryID; }
            set
            {
                _productSubcategoryID = value;
                NotifyPropertyChanged("ProductSubcategoryID");
            }
        }
        public string ModelId
        {
            get { return _modelId; }
            set
            {
                _modelId = value;
                NotifyPropertyChanged("ModelId");
            }
        }
        public DateTime SellStartDate
        {
            get { return _sellStartDate; }
            set
            {
                _sellStartDate = value;
                NotifyPropertyChanged("SellStartDate");
            }
        }
        #endregion





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
            this.Sizes = this.ProductRepository.GetSizes();
            this.SizesUnits = this.ProductRepository.GetSizesUnits();
            this.WeightUnits = this.ProductRepository.GetWeightUnits();
            this.ProductLines = this.ProductRepository.GetProductLines();
            this.Classes = this.ProductRepository.GetClasses();
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
