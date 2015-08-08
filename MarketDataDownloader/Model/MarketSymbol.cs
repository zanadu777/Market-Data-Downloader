using System;
using System.IO;
using System.Linq;
using System.Net;
using GalaSoft.MvvmLight;
using MarketDataDownloader.Extensions;

namespace MarketDataDownloader.Model
{
    public class MarketSymbol : ObservableObject
    {

        public MarketSymbol(string name)
        {
            Name = name;
            if (File.Exists(CachedDataPath))
            {
                LastUpdated = File.GetLastWriteTime(CachedDataPath);
                NumberOfEntries = File.ReadAllLines(CachedDataPath).Length - 1;
            }
        }
        public string Name { get; set; }

        private DateTime? lastUpdated;
        private int numberOfEntries;

        public DateTime? LastUpdated
        {
            get { return lastUpdated; }
            set { Set(() => LastUpdated, ref lastUpdated, value); }
        }

        private bool isStale;
        public bool IsStale
        {
            get
            {
                var path = CachedDataPath;
                if (!File.Exists(path))
                    return true;

                var fileDate = File.GetLastWriteTime(path).Date;
                var today = DateTime.Now.Date;
                return fileDate < today || isStale;
            }
            set { isStale = value; }
        }

        public void GetPriceHistoryFromYahoo()
        {

            using (var web = new WebClient())
            {
                if (!IsStale) return;

                string data =
                    web.DownloadString(string.Format("http://ichart.finance.yahoo.com/table.csv?s={0}&c={1}", Name,
                        1700));

                File.WriteAllText(CachedDataPath, data);
                isStale = false;
                NumberOfEntries = data.LineCount() -1;
                LastUpdated = File.GetLastWriteTime(CachedDataPath);
            }
        }

        private string CachedDataPath
        {
            get
            {

                return Path.Combine(App.CacheDirectoryPath, Name + ".csv");
            }
        }

        public int NumberOfEntries
        {
            get { return numberOfEntries; }
            set { Set(() => NumberOfEntries, ref numberOfEntries, value); }
        }
    }
}
