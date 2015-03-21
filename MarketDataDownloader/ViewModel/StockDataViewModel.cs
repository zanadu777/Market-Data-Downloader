using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MarketDataDownloader.Model;

namespace MarketDataDownloader.ViewModel
{
    public class StockDataViewModel : ViewModelBase
    {
        private StockDataModel Model { get; set; }
        private readonly BackgroundWorker fetchSymbolsWorker = new BackgroundWorker();
        private bool isNotBusy;

        public StockDataViewModel(StockDataModel model)
        {
            Model = model;


            WatchedSymbols = Model.WatchedSymbols;
            FilteredSymbols = new CollectionViewSource();
            FilteredSymbols.Source = watchedSymbols;
            FilteredSymbols.Filter += OnFilteredSymbolsOnFilter;


            FetchSymbols = new RelayCommand(FetchSymbolsFromYahoo);
            AddSymbolToWatched = new RelayCommand<string>(AddSymbol);

            fetchSymbolsWorker.DoWork += FetchSymbolsWorker_DoWork;
            fetchSymbolsWorker.RunWorkerCompleted += FetchSymbolsWorker_RunWorkerCompleted;

            IsNotBusy = true;

        }

        void FetchSymbolsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsNotBusy = true;
        }

        void FetchSymbolsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            IsNotBusy = false;
            foreach (var symbol in watchedSymbols)
            {
                symbol.GetPriceHistoryFromYahoo();
            }
        }



        public bool IsNotBusy
        {
            get { return isNotBusy; }
            set { Set(() => IsNotBusy, ref isNotBusy, value); }
        }

        public RelayCommand FetchSymbols { get; private set; }

        public RelayCommand<string> AddSymbolToWatched { get; private set; }




        private void FetchSymbolsFromYahoo()
        {

            fetchSymbolsWorker.RunWorkerAsync();
        }

        private void OnFilteredSymbolsOnFilter(object s, FilterEventArgs e)
        {
            var option = e.Item as MarketSymbol;

            if (string.IsNullOrWhiteSpace(Filter))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = option.Name.Contains(Filter.ToUpper());
            }
        }

        public string Filter
        {
            get { return filter; }
            set
            {
                if (value == filter) return;
                filter = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<MarketSymbol> watchedSymbols;
        public ObservableCollection<MarketSymbol> WatchedSymbols
        {
            get { return watchedSymbols; }
            set
            {
                watchedSymbols = value;
            }
        }

        public void AddSymbol(string symbol)
        {
            Model.AddSymbol(symbol);
        }


        private CollectionViewSource filteredSymbols;
        private string filter;

        public CollectionViewSource FilteredSymbols
        {
            get { return filteredSymbols; }
            set { filteredSymbols = value; }
        }


    }
}
