using ChromeCorners.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeCorners.CLI
{
    public class Configuration : IConfiguration
    {
        public string Url { get; set; }

        public string Filename { get; set; }

        public IScriptWriter ScriptWriter { get; }

        public IShortCutGenerator ShortCutGenerator { get; }
    }
}
