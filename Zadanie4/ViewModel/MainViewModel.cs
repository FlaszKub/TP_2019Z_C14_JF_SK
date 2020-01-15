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
        private bool _isEdit;
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
        public Product SelectedProduct
        {
            get { return _product; }
            set
            {
                _product = value;
            }
        }
        public ProductRepository ProductRepository { get; set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand AddCommand { get; private set; }

        public ICommand EditCommand { get; private set; }
        
        public ICommand ApplyCommand { get; private set; }

        public IWindow MainWindow { get; set; }

        public List<string> Colors { get; set; }
        public List<string> Sizes { get; set; }
        public List<string> SizesUnits { get; set; }
        public List<string> WeightUnits { get; set; }
        public List<string> ProductLines { get; set; }
        public List<string> Classes { get; set; }
        public List<string> Styles { get; set; }
        public List<string> ProductSubCategories { get; set; }
        public List<string> Models { get; set; }
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

        #region private data
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

        #region for Binding fields
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
        public string ProductSubcategoryName
        {
            get { return _productSubcategoryID; }
            set
            {
                _productSubcategoryID = value;
                NotifyPropertyChanged("ProductSubcategoryName");
            }
        }
        public string ModelName
        {
            get { return _modelId; }
            set
            {
                _modelId = value;
                NotifyPropertyChanged("ModelName");
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
            AddCommand = new OwnCommand(AddProduct);
            ProductRepository.ChangeInCollection += OnProductsChanged;
            _visibility = false;
            InitList();
            ApplyCommand = new OwnCommand(ApplyForEdit);
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
            this.Models = this.ProductRepository.GetModels();
        }

        private void InitEditProduct()
        {
            this.ProductName = this._product.Name;
            this.ProductNumber = this._product.ProductNumber;
            this.Color = this._product.Color;
            this.SafetyStockLevel = this._product.SafetyStockLevel;
            this.ReorderPoint = this._product.ReorderPoint;
            this.StandardCost = this._product.StandardCost;
            this.Size = this._product.Size;
            this.SizeUnitMeasureCode = this._product.SizeUnitMeasureCode;
            this.WeightUnitMeasureCode = this._product.WeightUnitMeasureCode;
            this.Weight = this._product.Weight;
            this.DaysToManufacture = this._product.DaysToManufacture;
            this.ProductLine = this._product.ProductLine;
            this.Class = this._product.Class;
            this.Style = this._product.Style;
            this.ProductSubcategoryName = this._product.ProductSubcategory?.Name;
            this.ModelName = this._product.ProductModel?.Name;
            this.SellStartDate = this._product.SellStartDate;

        }

        private void InitAddProduct()
        {
            this.ProductName = null;
            this.ProductNumber = null;
            this.Color = null;
            this.SafetyStockLevel = 0;
            this.ReorderPoint = 0;
            this.StandardCost = 0;
            this.Size = null;
            this.SizeUnitMeasureCode = null;
            this.WeightUnitMeasureCode = null;
            this.Weight = 0;
            this.DaysToManufacture = 0;
            this.ProductLine = null;
            this.Class = null;
            this.Style = null;
            this.ProductSubcategoryName = null;
            this.ModelName = null;
            this.SellStartDate = DateTime.Now;

        }


        #region methods for init command
        private void DeleteProduct()
        {
            if(SelectedProduct is null || SelectedProduct.ProductID <= 0)
            {
                MainWindow.ShowPopup("Select a product");
            } else
            {
                ProductRepository.Delete(SelectedProduct.ProductID);
            }
        }

        private void EditProduct()
        {
            this._isEdit = true;
            if (SelectedProduct is null || SelectedProduct.ProductID <= 0)
            {
                MainWindow.ShowPopup("Select a product");
            }
            else
            {
                InitEditProduct();
                Visibility = true;
            }
        }

        private void AddProduct()
        {
            _isEdit = false;
            InitAddProduct();
            Visibility = !Visibility;

            //tutaj napisz logie do przycisku add 
        }

        private void ApplyForEdit()
        {
            
            if (_isEdit)
            {
                InsetDataToProduct(this.SelectedProduct);
                ProductRepository.Update(this.SelectedProduct);
            }
            else
            {
                Product newProduct = new Product();
                InsetDataToProduct(newProduct);
                ProductRepository.Add(newProduct);
            }
            this.Visibility = false;
        }
        #endregion

        private void InsetDataToProduct(Product p)
        {
            p.Name = this.ProductName;
            p.ProductNumber = this.ProductNumber;
            p.Color = this.Color;
            p.SafetyStockLevel = this.SafetyStockLevel;
            p.ReorderPoint = this.ReorderPoint;
            p.StandardCost = this.StandardCost;
            p.Size = this.Size;
            p.SizeUnitMeasureCode = this.SizeUnitMeasureCode;
            p.WeightUnitMeasureCode = this.WeightUnitMeasureCode;
            p.Weight = this.Weight;
            p.DaysToManufacture = this.DaysToManufacture;
            p.ProductLine = this.ProductLine;
            p.Class = this.Class;
            p.Style = this.Style;
            if (this.ProductSubcategoryName != null)
            {
                p.ProductSubcategory = ProductRepository.GetProductSubcategoryForName(this.ProductSubcategoryName);
            }
            else {
                p.ProductSubcategoryID = null;
            }
            if (this.ModelName != null)
            {
                p.ProductModel = ProductRepository.GetProductModelForName(this.ModelName);
            }
            else
            {
                p.ProductModelID = null;
            }   
            p.SellStartDate = this.SellStartDate;
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
