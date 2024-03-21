using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;
using System;
using System.Windows.Input;
using System.Xml.Linq;
using WebSiteBlueMVVM.Views;

namespace WebSiteBlueMVVM.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _CurrentPage;
        bool[] ButtonAccess = new bool[5];
        public ViewModelBase CurrentPage
        {
            get { return _CurrentPage; }
            private set { this.RaiseAndSetIfChanged(ref _CurrentPage, value); }
        }
        public ViewModelBase[] Pages =
        {
            new HomeViewModel(),
            new ProductsViewModel(),
            new CartViewModel()
        };
        public MainWindowViewModel()
        {
            CurrentPage = Pages[0];
            ButtonAccess[0] = true;
        }
        public async void SignUpButton()
        {
            RegWindowView dialog = new RegWindowView();
            await dialog.ShowDialog((Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow).ConfigureAwait(true);
            MenuEnable = Manager.Reg;
        }
        public string Name
        {
            set; get;
        }
        private string _email = string.Empty;
        public string Email
        {
            get => _email; set => _email = value;
        }
        private bool _ViewVisible = true;
        public bool ViewVisible
        {
            get { return _ViewVisible; }
            set { this.RaiseAndSetIfChanged(ref _ViewVisible, value); }
        }
        private bool _menuEnable = false;
        public bool MenuEnable
        {
            get { return _menuEnable; }
            set { this.RaiseAndSetIfChanged(ref _menuEnable, value); }
        }
        public void ButtonMenu()
        {
            AllFalse();
            ButtonMenuAcces = true;
            CurrentPage = Pages[0];
        }
        public bool ButtonMenuAcces
        {
            get { return ButtonAccess[0]; }
            set { this.RaiseAndSetIfChanged(ref ButtonAccess[0], value); }
        }
        public void ButtonProducts()
        {
            AllFalse();
            ButtonProductsAccess = true;
            CurrentPage = Pages[1];
        }
        public bool ButtonProductsAccess
        {
            get { return ButtonAccess[1]; }
            set { this.RaiseAndSetIfChanged(ref ButtonAccess[1], value); }
        }
        public void ButtonAbout()
        {
            AllFalse();
            ButtonAboutAccess = true;
            CurrentPage = Pages[2];
        }
        public bool ButtonAboutAccess
        {
            get { return ButtonAccess[2]; }
            set { this.RaiseAndSetIfChanged(ref ButtonAccess[2], value); }
        }
        public void ButtonContacts()
        {
            AllFalse();
            ButtonContactsAccess = true; 
            ViewVisible = false;
        }
        public bool ButtonContactsAccess
        {
            get { return ButtonAccess[3]; }
            set { this.RaiseAndSetIfChanged(ref ButtonAccess[3], value); }
        }
        void AllFalse()
        {
            ViewVisible = true;
            ButtonMenuAcces = false;
            ButtonProductsAccess = false;
            ButtonAboutAccess = false;
            ButtonContactsAccess = false;
        }

    }
}