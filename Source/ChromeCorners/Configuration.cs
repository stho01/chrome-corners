using ChromeCorners.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChromeCorners
{
    public class Configuration : IConfiguration
    {
        public IScriptWriter ScriptWriter { get; set; }             
        public IShortCutGenerator ShortCutGenerator { get; set; }
        public IWebService WebService { get; set; }
    }
}
