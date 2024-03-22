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
            get
            {
                return Products.Bproducts.Where(p => p.Buyer == Manager.GetIndex(Manager.GetOrSetCurEmail)).ToList();
            }
        }
        public void Delete()
        {
            foreach (BuyingProduct p in SelectedItems)
            {
                Products.Bproducts.Remove(p);
            }
        }
        List<BuyingProduct> _selectedItems = new List<BuyingProduct>();
        public List<BuyingProduct> SelectedItems
        {
            get { return _selectedItems; }
            set { this.RaiseAndSetIfChanged(ref _selectedItems, value); }
        }
    }
}
