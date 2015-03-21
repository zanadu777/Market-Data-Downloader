using System.Windows;
using MarketDataDownloader.ViewModel;

namespace MarketDataDownloader
{
    /// <summary>
    /// Interaction logic for StockDataMainWindow.xaml
    /// </summary>
    public partial class StockDataMainWindow : Window
    {
        public StockDataMainWindow()
        {
            InitializeComponent();
        }

        private void txtSymbol_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var viewModel = (StockDataViewModel)this.DataContext;
            viewModel.Filter = txtSymbol.Text;
            viewModel.FilteredSymbols.View.Refresh();
        }


    }
}
