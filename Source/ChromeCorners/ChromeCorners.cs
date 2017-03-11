using ChromeCorners.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChromeCorners
{
    public class ChromeCorners : IChromeCornerService
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly ChromeCorners Instance = new ChromeCorners();

        /// <summary>
        /// 
        /// </summary>
        private Configuration _config;

        /// <summary>
        /// 
        /// </summary>
        private ChromeCorners()
        {
            // Defaults.
            _config = new Configuration
            {
                ScriptWriter      = new DefaultScriptWriter(),
                ShortCutGenerator = new DefaultShortCutGenerator(),
                WebService        = new WebService.Service(),
                IconDownloader    = new WebService.FaviconDownloader()
            };
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public IChromeCornerService Configure(IConfiguration config)
        {
            _config = new Configuration
            {
                ScriptWriter      = config.ScriptWriter      ?? _config.ScriptWriter,
                ShortCutGenerator = config.ShortCutGenerator ?? _config.ShortCutGenerator,
                WebService        = config.WebService        ?? _config.WebService,
                IconDownloader    = config.IconDownloader    ?? _config.IconDownloader
            };
            return Instance;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Create(string filename, string url)
        {
            var createdFile     = _config.ScriptWriter.WriteScript(filename, url);
            var shortCutPath    = Path.GetFullPath(createdFile);
            var desktopPath     = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var iconPath        = DownloadIcon(url);

            _config.ShortCutGenerator.CreateShortcut(
                Path.GetFileNameWithoutExtension(createdFile),
                desktopPath,
                shortCutPath,
                iconPath);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string DownloadIcon(string url)
        {
            var iconUrl         = _config.WebService.FindFaviconUrlFromWebsite(url);
            var fileNameAndPath = Environment.CurrentDirectory + "/" + "icon.ico";

            _config.IconDownloader.DownloadAndSaveIcon(iconUrl, fileNameAndPath);

            return fileNameAndPath;
        }
    }
}