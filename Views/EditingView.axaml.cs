using Avalonia.Controls;
using Avalonia.Interactivity;

namespace WebSiteBlueMVVM.Views
{
    public partial class EditingView : Window
    {
        public EditingView()
        {
            InitializeComponent();
        }
        public void WinClose(object sender, RoutedEventArgs args)
        {
            Close();
        }
    }
}

