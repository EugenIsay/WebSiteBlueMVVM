using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;
using WebSiteBlueMVVM.Views;

namespace WebSiteBlueMVVM.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        RegWindowView dialog = new RegWindowView();
        public MainWindowViewModel() 
        {

        }
        public void SignUpButton()
        {
            dialog.ShowDialog((Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow).ConfigureAwait(false);

        }
        public void ClosrLogin()
        {
            dialog.Close();
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