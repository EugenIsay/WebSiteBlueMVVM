using Avalonia.Controls;
using ReactiveUI;
using WebSiteBlueMVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Avalonia.Interactivity;

namespace WebSiteBlueMVVM.ViewModels
{
    public class EditingViewModel : ViewModelBase
    {
        public EditingViewModel()
        {

        }
        public EditingViewModel(int i) 
        {
            index = i;
            Name = Products.GetListP[index].Name;
            Price = Products.GetListP[index].Cost;
            Amount = Products.GetListP[index].Amount;
            //
        }
        int index = -1;
        string _name = string.Empty;
        public string Name { get { return _name; } set { this.RaiseAndSetIfChanged(ref _name, value); } }

        double _price = 0;
        public double Price { get { return _price; } set { this.RaiseAndSetIfChanged(ref _price, value); } }

        int _amount = 0;
        public int Amount { get { return _amount; } set { this.RaiseAndSetIfChanged(ref _amount, value); } }
        public void Comfirm(object sender, RoutedEventArgs args)
        {
            if (Name != string.Empty && _price > 0)
            {
                if (index == -1)
                {
                    Products.Add_Product(Manager.GetIndex(Manager.GetOrSetCurEmail), Price, Name, Amount);
                }
                else if (index >= 0)
                {
                    Products.GetListP[index].Name = Name;
                    Products.GetListP[index].Cost = Price;
                    Products.GetListP[index].Amount = Amount;
                }
          
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
