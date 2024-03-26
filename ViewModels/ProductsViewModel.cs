﻿using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WebSiteBlueMVVM.Views;

namespace WebSiteBlueMVVM.ViewModels
{
    public class ProductsViewModel : ViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        private List<Product> _product;
        public List<Product> Product 
        {
            get { return _product; }
            set { this.RaiseAndSetIfChanged(ref _product, value); }
        }

        public async void AddProd() 
        {
            EditingView dialog = new EditingView();
            await dialog.ShowDialog((Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow).ConfigureAwait(true);
            Product = Products.GetListP;
        }

        public async void AddProdToBuyList()
        {
            if (SelectedItems != null && SelectedItems.Count != 0)
            {
                foreach (Product p in SelectedItems)
                {
                    if (!Products.Bproducts.Contains(Products.Bproducts.Find(po => po.Buyer == Manager.GetIndex(Manager.GetOrSetCurEmail) && po.ProductID == Products.GetListP.IndexOf(p) && po.Purchased == false)))
                    {
                        Products.Bproducts.Add(new BuyingProduct { ProductID = Products.GetListP.IndexOf(p), Buyer = Manager.GetIndex(Manager.GetOrSetCurEmail) });
                    }
                }
            }
        }
        public async void DelProd()
        {
            if (Products.IsEmpty() && SelectedIndex >= 0)
            {
                Products.Delete(SelectedIndex);
                Product = Products.GetListP;
            }
        }

        public List<Product> ListBox
        {
            get { return Products.GetListP; }
        }
        public bool BoxAvalible
        {
            get { return Products.IsEmpty(); }
        }
        bool _ShopOrProd = true;
        public bool ShopOrProd
        {
            get { return _ShopOrProd; }
            set { this.RaiseAndSetIfChanged(ref _ShopOrProd, value); }
        }

        int _selectedIndex;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set { this.RaiseAndSetIfChanged(ref _selectedIndex, value); }
        }

        int _plusButton;
        public int PlusButton
        {
            get { return _plusButton; }
            set { this.RaiseAndSetIfChanged(ref _plusButton, value); }
        }


        List<Product> _selectedItems = new List<Product>();
        public List<Product> SelectedItems
        {
            get { return _selectedItems; }
            set { this.RaiseAndSetIfChanged(ref _selectedItems, value); }
        }

        public void ChangeButtonToShop()
        {
            ShopOrProd = true;
        }
        public void ChangeButtonToProd()
        {
            ShopOrProd = false;
        }



    }
}
