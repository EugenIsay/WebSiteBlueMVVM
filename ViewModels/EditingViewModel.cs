using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteBlueMVVM.ViewModels
{
    public class EditingViewModel : ViewModelBase
    {
        string _name = string.Empty;
        public string Name { get { return _name; } }

        double _price = 0;
        public double Price { get { return _price; } }

        int _amount = 0;
        public int Amount { get { return _amount; } }

    }
}
