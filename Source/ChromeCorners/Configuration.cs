using ChromeCorners.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChromeCorners
{
    public class Configuration : IConfiguration
    {
        public IScriptWriter ScriptWriter { get; set; }             = new DefaultScriptWriter();
        public IShortCutGenerator ShortCutGenerator { get; set; }   = new DefaultShortCutGenerator();
    }
}
