using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeCorners.Core
{
    public interface IIconDownloader
    {
        byte[] DownloadIcon(string url);
        void DownloadAndSaveIcon(string url, string filename);
        void SaveIcon(byte[] data, string filename);
    }
}
