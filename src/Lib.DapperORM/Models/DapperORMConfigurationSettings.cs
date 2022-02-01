using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DapperORM.Models
{
    public class DapperORMConfigurationSettings
    {
        public void SetDefaultConnectionString(string connectionString) => SharedSettings.ConnectionString = connectionString;
        public void UseFileLogging() => SharedSettings.EnableLogging = true;
        public string SetFileLogPath(string filePath) => SharedSettings.LogPath = filePath;
       
    }
}
