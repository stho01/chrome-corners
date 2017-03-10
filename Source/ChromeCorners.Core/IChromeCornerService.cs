using System;
using System.Collections.Generic;
using System.Text;

namespace ChromeCorners.Core
{
    public interface IChromeCornerService
    {
        IChromeCornerService Configure(IConfiguration config);
        bool Create(string filename, string url);
    }
}
