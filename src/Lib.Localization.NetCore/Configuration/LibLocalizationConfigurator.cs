using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Localization.Web.Configuration
{
    public class LibLocalizationConfigurator
    {
        public void SetConnectionString(string connectionString)
        {
            Lib.Localization.Web.SharedSettings.ConnectionString = connectionString;
        }
    }
}
