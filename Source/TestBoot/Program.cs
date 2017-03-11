using ChromeCorners.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBoot
{
    class Program
    {
        static void Main(string[] args)
        {
            var webService = new ChromeCorners.WebService.Service();
            webService.FindFaviconUrlFromWebsite("http://oxx.no");
        }
    }
}
