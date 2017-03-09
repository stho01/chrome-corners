using ChromeCorners.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChromeCorners
{
    internal class Configuration : IConfiguration
    {
        public string Url { get; private set; }
        public string Filename { get; private set; }
        public IScriptWriter ScriptWriter { get; private set; }
        public IShortCutGenerator ShortCutGenerator { get; private set; }

        public void Clone(IConfiguration config)
        {
            Url                 = config.Url;
            Filename            = config.Filename;
            ScriptWriter        = config.ScriptWriter ?? new DefaultScriptWriter();
            ShortCutGenerator   = config.ShortCutGenerator ?? new DefaultShortCutGenerator();
        }
    }
}
