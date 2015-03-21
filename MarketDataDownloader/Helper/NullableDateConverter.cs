using System;
using System.Globalization;
using System.Windows.Data;

namespace MarketDataDownloader.Helper
{
    public class NullableDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "";

            DateTime returnVal;

            if (DateTime.TryParse(value.ToString(), out returnVal))
            {
                if (returnVal != DateTime.MinValue)
                    return returnVal.Date.ToShortDateString();
                else
                    return "";
            }
            else
                return "";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
