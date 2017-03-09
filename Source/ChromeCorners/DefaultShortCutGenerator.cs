﻿using ChromeCorners.Core;
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
        public void CreateShortcut(string shortcutName, string shortcutPath, string targetFileLocation)
        {
            string shortcutLocation = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk");
            WshShell shell          = new WshShell();
            IWshShortcut shortcut   = (IWshShortcut)shell.CreateShortcut(shortcutLocation);
            shortcut.Description    = "My shortcut description";   // The description of the shortcut
            shortcut.IconLocation   = @"c:\myicon.ico";           // The icon of the shortcut
            shortcut.TargetPath     = targetFileLocation;           // The path of the file that will launch when the shortcut is run
            shortcut.Save();                                    // Save the shortcut
        }
    }
}
