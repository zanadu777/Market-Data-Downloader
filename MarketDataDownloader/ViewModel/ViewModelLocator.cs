using MarketDataDownloader.Model;

namespace MarketDataDownloader.ViewModel
{
    class ViewModelLocator
    {
        public StockDataViewModel Main { get; private set; }

        public ViewModelLocator()
        {
            
            Main = new StockDataViewModel(new StockDataModel());
        }
    }
}
