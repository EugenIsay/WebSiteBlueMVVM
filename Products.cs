using System;
using System.Collections.Generic;
using ReactiveUI;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tmds.DBus.SourceGenerator;
using System.Reflection;
using DynamicData;
using System.Collections.ObjectModel;
using Avalonia.Controls.ApplicationLifetimes;
using WebSiteBlueMVVM.Views;

namespace WebSiteBlueMVVM
{
    public static class Products 
    {
        private static ObservableCollection<Product> products = new ObservableCollection<Product>();

        public static ObservableCollection<BuyingProduct> Bproducts = new ObservableCollection<BuyingProduct>();
        public static event EventHandler MyStaticPropertyChanged;


        public static ObservableCollection<Product> GetListP
        {
            get { return products; }
        }
        public static void Add_Product(int saller, double cost, string name, int am)
        {
            products.Add(new Product() { Saller = saller, Cost = cost, Name = name, Amount = am });
            MyStaticPropertyChanged?.Invoke(null, EventArgs.Empty);
        }
        public static int GetUser(int i)
        {
            return products[i].Saller;
        }
        public static double GetCost(int i)
        {
            return products[i].Cost;
        }
        public static string Name(int i)
        {
            return products[i].Name;
        }
        public static int Amount(int i)
        {
            return products[i].Amount;
        }
        public static bool IsEmpty()
        {
            if (products.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void Delete(int i)
        {
            products.RemoveAt(i);

            //Bproducts.Remove(Bproducts.FindAll(f => f.ProductID == i));
        }
        
    }
    public class Product : INotifyPropertyChanged
    {
        private int _saller;
        public int Saller
        { 

            get { return _saller; } 
            set { _saller = value; } 
        }

        private double _cost = 00.00;
        public double Cost { get { return _cost; } set { _cost = value; } }

        private string _name = string.Empty;
        public string Name { get { return _name; } set { _name = value;
                OnPropertyChanged(nameof(Name)); ; } }

        private int _amount = 1;
        public int Amount { get { return _amount; } set { _amount = value; } }
        private int _sold = 0;
        public int Sold { get { return _sold; } set { _sold = value; } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private int _watchd = 1;
        public int Watchd
        {
            get { return _watchd; }
            set {
                if (value > Amount)
                {
                    _watchd = Amount;
                }
                else if(value <= 0)
                {
                    _watchd = 1;
                }
                else
                {
                    _watchd = value;
                }
                OnPropertyChanged(nameof(Watchd));
            }
        }
        int _plusButton;
        public int PlusButton
        {
            get { return _plusButton; }
            set { _plusButton = value; }
        }
        public async void PlusBut()
        {
            Watchd++;
        }
        int _minusButton;
        public int MinusButton
        {
            get { return _minusButton; }
            set { _minusButton = value; }
        }
        public async void MinusBut()
        {
            Watchd--;
        }
        int _delInd;
        public int DelInd
        {
            get { return _delInd; }
            set { _delInd = value; }
        }
        public async void DeleteBut()
        {
            Products.Bproducts[Products.Bproducts.IndexOf(Products.Bproducts.FirstOrDefault(po => po.ProductID == FindMyInd))].Delete(FindMyInd);
            Products.Delete(FindMyInd);
        }
        int _cartInd = 0;
        public int CartInd
        {
            get { return _cartInd; }
            set { _cartInd = value; }
        }
        int FindMyInd
        {
            get { return Products.GetListP.IndexOf(Products.GetListP.FirstOrDefault(po => po.Saller == Saller && po.Cost == Cost && po.Name == Name && po.Amount == Amount)); }
        }
        public async void AddToCart()
        {
            var existingProduct = Products.Bproducts.Contains(Products.Bproducts.FirstOrDefault(po =>  po.ProductID == FindMyInd));
            if (!existingProduct)
            {
                Products.Bproducts.Add(new BuyingProduct { ProductID = FindMyInd, Buyer = Manager.GetIndex(Manager.GetOrSetCurEmail) });
            }
        }
        public async void Redact()
        {
            EditingView dialog = new EditingView();
            //await dialog.ShowDialog((Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow).ConfigureAwait(true);
        }
    }

    public class BuyingProduct
    {
        private int _productid;
        public int ProductID
        {
            get { return _productid; }
            set { _productid = value; }
        }
        public Product Product
        {
            get { return Products.GetListP[ProductID]; }
        }
        private int _buyer;
        public int Buyer
        {
            get { return _buyer; }
            set { _buyer = value; }
        }
        private bool _purchased = false;
        public bool Purchased
        {
            get { return _purchased; }
            set { _purchased = value; }
        }
        int _delIndex;
        public int DelIndex
        {
            get { return _delIndex; }
            set { _delIndex = value; }
        }
        public async void Delete()
        {
            Delete(DelIndex);
        }
        public void Delete(int p)
        {
            Products.Bproducts.Remove(Products.Bproducts.FirstOrDefault(f => f.ProductID == p));
        }

    }
}
