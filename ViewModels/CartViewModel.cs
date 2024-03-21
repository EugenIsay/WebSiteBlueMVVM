using ReactiveUI;
using System.Collections.Generic;
using System.Linq;
using WebSiteBlueMVVM.Views;

namespace WebSiteBlueMVVM.ViewModels
{
    public class CartViewModel : ViewModelBase
    {
        public List<BuyingProduct> ListBox
        {
            get {
                return Products.Bproducts.Where(p => p.Buyer == Manager.GetIndex(Manager.GetOrSetCurEmail)).ToList();
            }
        }
    }
}
