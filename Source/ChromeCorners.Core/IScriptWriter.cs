using System;
using System.Collections.Generic;
using System.Text;

namespace ChromeCorners.Core
{
    public interface IScriptWriter
    {
        string WriteScript(string filename, string url);
    }
}