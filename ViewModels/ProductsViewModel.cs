using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteBlueMVVM.ViewModels
{
    public class ProductsViewModel : ViewModelBase
    {
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
    }
}
