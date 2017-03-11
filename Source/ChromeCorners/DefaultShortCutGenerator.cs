using ChromeCorners.Core;
using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeCorners
{
    public class DefaultShortCutGenerator : IShortCutGenerator
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="shortcutName"></param>
        /// <param name="shortcutPath"></param>
        /// <param name="targetFileLocation"></param>
        /// <param name="iconPath"></param>
        public void CreateShortcut(string shortcutName, string shortcutPath, string targetFileLocation, string iconPath = null)
        {
            var shortcutLocation    = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk");
            var shell               = new WshShell();
            var shortcut            = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description    = "My shortcut description";  // The description of the shortcut
            shortcut.IconLocation   = iconPath;                   // The icon of the shortcut
            shortcut.TargetPath     = targetFileLocation;         // The path of the file that will launch when the shortcut is run
            shortcut.Save();                                      // Save the shortcut
        }
    }
}