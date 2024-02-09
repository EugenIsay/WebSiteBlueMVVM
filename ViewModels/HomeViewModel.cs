using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteBlueMVVM.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public List<User> ListBox
        {
            get => GerList();
        }
        public List<User> GerList()
        {
            return Manager.Users;
        }
    }
}
