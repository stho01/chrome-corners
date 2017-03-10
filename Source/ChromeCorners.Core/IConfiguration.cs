using System;
using System.Collections.Generic;
using System.Text;

namespace ChromeCorners.Core
{
    public interface IConfiguration
    {
        IScriptWriter ScriptWriter { get; }
        IShortCutGenerator ShortCutGenerator { get; }
    }
}
