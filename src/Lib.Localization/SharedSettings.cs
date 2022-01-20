using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Localization
{
    internal class SharedSettings : Lib.Core.SharedSettings
    {
        public static string ConnectionString { get; set; } = string.Empty;
    }
}
