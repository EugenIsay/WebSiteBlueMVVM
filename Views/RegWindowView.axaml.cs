using Avalonia.Controls;
using Avalonia.Interactivity;

namespace WebSiteBlueMVVM.Views
{
    public partial class RegWindowView : Window
    {
        public RegWindowView()
        {
            InitializeComponent();
        }
        public void WinClose(object sender, RoutedEventArgs args)
        {
            Close();
        }
        
    }
}