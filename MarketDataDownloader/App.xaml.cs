using System;
using System.IO;
using System.Windows;

namespace MarketDataDownloader
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static String CacheDirectoryPath { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (Directory.Exists(MarketDataDownloader.Properties.Settings.Default.CachedMarketDataPath))
                CacheDirectoryPath = MarketDataDownloader.Properties.Settings.Default.CachedMarketDataPath;
            else
            {
                CacheDirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HistoricalMarketData");
                var di = new DirectoryInfo(CacheDirectoryPath);
                if (!di.Exists)
                    di.Create();
            }
        }
    }
}

