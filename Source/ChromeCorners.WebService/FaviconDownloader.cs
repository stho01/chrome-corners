using ChromeCorners.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ChromeCorners.WebService
{
    public class FaviconDownloader : IIconDownloader
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public byte[] DownloadIcon(string url)
        {
            using (var webClient = new WebClient())
            {
                return webClient.DownloadData(url);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filename"></param>
        public void SaveIcon(byte[] data, string filename)
        {
            File.WriteAllBytes(filename, data);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="url"></param>
        /// <param name="filename"></param>
        public void DownloadAndSaveIcon(string url, string filename)
        {
            var data = DownloadIcon(url);
            SaveIcon(data, filename);
        }
    }
}