using System;
using System.IO;
using System.Net;
using GalaSoft.MvvmLight;

namespace MarketDataDownloader.Model
{
    public class MarketSymbol : ObservableObject
    {

        public MarketSymbol(string name)
        {
            Name = name;
            if (File.Exists(CachedDataPath))
                LastUpdated = File.GetLastWriteTime(CachedDataPath);
        }
        public string Name { get; set; }

        private DateTime? lastUpdated;
        public DateTime? LastUpdated
        {
            get { return lastUpdated; }
            set { Set(() => LastUpdated, ref lastUpdated, value); }
        }

        public bool IsStale
        {
            get
            {
                var path = CachedDataPath;
                if (!File.Exists(path))
                    return true;

                var fileDate = File.GetLastWriteTime(path).Date;
                var today = DateTime.Now.Date;
                return fileDate < today;
            }
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



    }
}
