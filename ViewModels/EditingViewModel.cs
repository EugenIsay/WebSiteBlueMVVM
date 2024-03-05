using Avalonia.Controls;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WebSiteBlueMVVM.ViewModels
{
    public class EditingViewModel : ViewModelBase
    {
        string _name = string.Empty;
        public string Name { get { return _name; } set { this.RaiseAndSetIfChanged(ref _name, value); } }

        double _price = 0;
        public double Price { get { return _price; } set { this.RaiseAndSetIfChanged(ref _price, value); } }

        int _amount = 0;
        public int Amount { get { return _amount; } set { this.RaiseAndSetIfChanged(ref _amount, value); } }
        public void Comfirm()
        {
            if (Name != string.Empty && _price > 0)
            {
                Products.Add_Product( Manager.GetIndex(Manager.GetOrSetCurEmail) ,Price,Name , Amount);
                //var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.DataContext == this);
            }
        }

    }
}
