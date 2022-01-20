using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.DapperORM.WinForms
{
    public static class Configurator
    {
        public static void Config(Action<Lib.DapperORM.Models.DapperORMConfigurationSettings> config)
        {

            config.Invoke(new Models.DapperORMConfigurationSettings());
        }
    }
}
