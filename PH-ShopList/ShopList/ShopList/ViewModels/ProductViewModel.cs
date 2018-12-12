using ShopList.Model;
using ShopList.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopList.ViewModels
{
    class ProductViewModel : INotifyPropertyChanged
    {
        private bool IsBusy;

        public ProductViewModel()
        {
            LoadProductsCommand = new Command(async () => await GetAllProducts(), () => !IsBusy);
        }

        private ObservableCollection<ProductModel> _productList;

        public ObservableCollection<ProductModel> ProductList
        {
            get
            {
                if (_productList == null)
                {
                    _productList = new ObservableCollection<ProductModel>();
                }
                return _productList;
            }

            set
            {
                if (_productList != value)
                {
                    _productList = value;
                    OnPropertyChanged();                
                }
            }
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            IsBusy = true;
            ProductService ps = new ProductService();
            var productList = await ps.GetAllProducts();

            foreach (var item in productList)
            {
                ProductList.Add(new ProductModel()
                {
                    ProductId = item.ProductId,
                    CodeProduct = item.CodeProduct,
                    Description = item.Description,
                    Price = item.Price,
                    UM = item.UM
                });
            }


            IsBusy = false;
            return productList;
            
        }

        public Command LoadProductsCommand{ get; set; }

        #region MyProperties definition

        private int productId;

        public int ProductId
        {
            get { return productId; }
            set
            {
                productId = value;
                OnPropertyChanged();
            }
        }
        
        private string codeProduct;

        public string CodeProduct
        {
            get { return codeProduct; }
            set
            {
                codeProduct = value;
                OnPropertyChanged();
            }
        }
        
        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }
        
        private string um;

        public string UM
        {
            get { return um; }
            set
            {
                um = value;
                OnPropertyChanged();
            }
        }
        
        private decimal price;

        public decimal Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region PropertyCHanged event
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        
    }
}
