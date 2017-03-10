﻿using ChromeCorners.Core;
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
        private ChromeCorners() { }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public IChromeCornerService Configure(IConfiguration config)
        {
            _config = new Configuration();
            _config.Clone(config);

            return Instance;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Create(string filename, string url)
        {
            var createdFile     = _config.ScriptWriter.WriteScript(filename, url);
            var shortCutPath    = Path.GetFullPath(createdFile);
            var desktop         = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            _config.ShortCutGenerator.CreateShortcut(Path.GetFileNameWithoutExtension(createdFile), desktop, shortCutPath);

            return true;
        }
    }
}