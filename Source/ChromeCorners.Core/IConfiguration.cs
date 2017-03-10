using System;
using System.Collections.Generic;
using System.Text;

namespace ChromeCorners.Core
{
    public interface IConfiguration
    {
        //string Url { get; }
        //string Filename { get; }
        IScriptWriter ScriptWriter { get; }
        IShortCutGenerator ShortCutGenerator { get; }
    }
}
