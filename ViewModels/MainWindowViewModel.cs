using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using System;
using WebSiteBlueMVVM.Views;

namespace WebSiteBlueMVVM.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ViewModelBase[] viewModelBase =
        {
            new RegWindowViewModel()
        };

        public MainWindowViewModel()
        {

        }
        public async void SignUpButton()
        {
            RegWindowView dialog = new RegWindowView();
            //var viewModel = new RegWindowViewModel();
            //viewModel.RequestClose += window.Close;
            await dialog.ShowDialog((Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow).ConfigureAwait(false);
            dialog.Close();
        }
        public void CloseLogin()
        {

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
        private bool _registrated = false;
        public bool Registrated
        {
            get => _registrated;
            set => _registrated = value;
        }
        public bool PersonRegistrated()
        {
            if (Manager.GetIndex(Email) == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool MenuEnable
        {
            get => PersonRegistrated();
        }
    }
}