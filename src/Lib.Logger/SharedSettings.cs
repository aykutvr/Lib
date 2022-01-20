using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Logger
{
    public enum LoggingType
    {
        Database,
        File,
        None
    }
    internal class SharedSettings : Lib.Core.SharedSettings
    {
      
        public static LoggingType LogType { get; set; } = LoggingType.File;
        public static string ConnectionString { get; set; } = string.Empty;
        public static string FolderPath { get; set; } = string.Empty;
        public static bool DailyLogging { get; set; } = false;
    }
}
