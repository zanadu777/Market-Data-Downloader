using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataDownloader.Extensions
{
   public static  class StringExtensions
    {
        public static int LineCount(this string text)
        {
            var counter = 0;
            using (var sr = new StringReader(text))
            {
                while ((sr.ReadLine()) != null)
                    counter++;
            }
            return counter;
        }
    }
}
