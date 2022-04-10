using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Redis
{
    internal class SharedSettings : Lib.Core.SharedSettings
    {
        public static string RedisServer { get; set; } = string.Empty;
        public static int RedisServerPort { get; set; } = 0;
    }
}
