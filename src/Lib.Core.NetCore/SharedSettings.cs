using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Core.Web
{
    public class SharedSettings : Lib.Core.SharedSettings
    {
        public static IServiceProvider ServiceProvider { get; set; }
    }
}
