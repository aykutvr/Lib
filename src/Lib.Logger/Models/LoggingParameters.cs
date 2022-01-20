using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Logger.Models
{
    public class LoggingParameters
    {
        public DateTime LogTime { get; set; } = DateTime.Now;
        public string Message { get; set; } = "";
        public string Details { get; set; } = "";
        public LogLevel LogLevel { get; set; } = LogLevel.Error;
        public string SpecialFolderName { get; set; } = "";
        public string SpecialLogFileName { get; set; } = "";
        public bool UseDateIndicatorInLogFileName { get; set; } = true;
        public Lib.Logger.LoggingType LogType { get; set; } = Lib.Logger.LoggingType.None;
    }
}
