using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DapperORM
{
    internal class SharedSettings
    {
        internal static string ConnectionString { get; set; } = string.Empty;
        internal static bool EnableLogging { get; set; } = false;
        internal static string LogPath { get; set; } = string.Empty;
    }
}
