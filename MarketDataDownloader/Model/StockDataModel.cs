using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using GalaSoft.MvvmLight;

namespace MarketDataDownloader.Model
{
    public class StockDataModel : ObservableObject
    {


        public ObservableCollection<MarketSymbol> WatchedSymbols { get; set; }
        public StockDataModel()
        {
            var dir = Environment.CurrentDirectory;
            var path = Path.Combine(dir, "MarketSymbols.txt");

            if (!File.Exists(path))
                return;

            var lines = File.ReadAllLines(path);
            var allSymbols = new List<MarketSymbol>();
            foreach (var line in lines)
            {
                var marketSymbol = ConstructSymbol(line);
                allSymbols.Add(marketSymbol);
            }

            var sorted = from m in allSymbols
                         orderby m.Name
                         select m;


            WatchedSymbols = new ObservableCollection<MarketSymbol>();
            foreach (var symbol in sorted)
            {
                WatchedSymbols.Add(symbol);
            }

        }

        private MarketSymbol ConstructSymbol(string text)
        {
            var marketSymbol = new MarketSymbol(text.Trim().ToUpper());

            return marketSymbol;
        }

        public void AddSymbol(string symbol)
        {
            if (IsSymbolWatched(symbol))
                return;

            var dir = Environment.CurrentDirectory;
            var path = Path.Combine(dir, "StockSymbols.txt");
            symbol = symbol.ToUpper();
            File.AppendAllText(path, Environment.NewLine + symbol);

            WatchedSymbols.Add(ConstructSymbol(symbol));

        }

        public bool IsSymbolWatched(string symbol)
        {

            var existing = (from MarketSymbol s in WatchedSymbols
                            where s.Name == symbol.ToUpper()
                            select s).Count();
            return existing != 0;
        }
    }
}
