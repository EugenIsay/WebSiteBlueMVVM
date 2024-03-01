using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSiteBlueMVVM.Views;

namespace WebSiteBlueMVVM.ViewModels
{
    public class ProductsViewModel : ViewModelBase
    {
        public async void AddProd() 
        {
            EditingView dialog = new EditingView();
            await dialog.ShowDialog((Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow).ConfigureAwait(true);
        }
        public List<Product> ListBox
        {
            get => GetList();
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
