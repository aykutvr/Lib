using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Logger.Models
{
    public class LoggerConfiguration
    {
        public void SetLogType(LoggingType logType) => SharedSettings.LogType = logType;
        public void SetDbLoggingConnectionString(string connectionString) => SharedSettings.ConnectionString =  connectionString;
        public void SetDailyLogging() => SharedSettings.DailyLogging = true;
        public void SetLogFolderPath(string folderPath) => SharedSettings.FolderPath = folderPath;
    }
}
