using ChromeCorners.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBoot
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            TestWebService();
        }

        /// <summary>
        /// 
        /// </summary>
        internal static void TestWebService()
        {
            var webService     = new ChromeCorners.WebService.Service();
            var iconUrl        = webService.FindFaviconUrlFromWebsite("http://oxx.no");
            var iconDownloader = new ChromeCorners.WebService.FaviconDownloader();
            var iconData       = iconDownloader.DownloadIcon(iconUrl);

            File.WriteAllBytes("icon.ico", iconData);

            Console.WriteLine(iconUrl);
            Console.WriteLine(iconData.Length);
        }
    }
}