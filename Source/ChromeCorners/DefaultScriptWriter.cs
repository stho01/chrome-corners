using ChromeCorners.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChromeCorners
{
    public class DefaultScriptWriter : IScriptWriter
    {
        /// <summary>
        /// Returns the filename of the created file
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public string WriteScript(string filename, string url)
        {
            var appPath       = AppDomain.CurrentDomain.BaseDirectory;
            var template      = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Resources/Template.txt");
            var scriptContent = string.Format(template, url);
            var fn            = CheckFilename(filename);
            
            File.WriteAllText(Environment.CurrentDirectory + "/" + fn, scriptContent);
            Console.WriteLine($"{fn} successfully created");
            return fn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private static string CheckFilename(string filename)
        {
            if (string.IsNullOrEmpty(filename))
                filename = "script.cmd";

            if (!filename.ToLower().EndsWith(".cmd")
             && !filename.ToLower().EndsWith(".bat"))
                filename = $"{filename}.cmd";

            return filename;
        }
    }
}
