using System;
using System.Collections.Generic;
using System.Text;

namespace ChromeCorners.Core
{
    public interface IShortCutGenerator
    {
        void CreateShortcut(string shortcutName, string shortcutPath, string targetFileLocation, string iconPath = null);
    }
}
