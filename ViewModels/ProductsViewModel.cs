using Avalonia;
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
        new public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void AddProd() 
        {
            EditingView dialog = new EditingView();
            await dialog.ShowDialog((Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow).ConfigureAwait(true);
            OnPropertyChanged(nameof(ListBox));
        }
        public async void DelProd()
        {
            if (Products.IsEmpty())
            {
                Products.Delete(SelectedIndex);
            }
        }

        public List<Product> ListBox
        {
            get { return Products.products; }
        }
        public List<Product> GetList()
        {
            return Products.products;
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
