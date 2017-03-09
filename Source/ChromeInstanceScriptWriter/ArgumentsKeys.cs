using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeCorners
{
    public static class Arguments
    {
        public static readonly Argument URL     = new Argument("url", "The url that shall be opened within the new chrome instance");
        public static readonly Argument NAME    = new Argument("name", "The name of the file");
    }
}
