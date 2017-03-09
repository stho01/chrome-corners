using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeInstanceScriptWriter
{
    public class Argument
    {
        public string ArgumentKey { get; }
        public string FriendlyName { get; set; }
        public string Description { get; }

        public Argument(string argKey, string desc)
        {
            ArgumentKey = argKey;
            Description = desc;
        }

        public override string ToString()
        {
            return string.Format("\t{0, -10} - {1}", ArgumentKey, Description);
        }
    }

    public static class Arguments
    {
        public static readonly Argument URL     = new Argument("url", "The url that shall be opened within the new chrome instance");
        public static readonly Argument NAME    = new Argument("name", "The name of the file");
    }
}
