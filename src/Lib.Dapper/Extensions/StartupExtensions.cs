using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddLibDapper(this IServiceCollection services)
        {
            services.AddTransient<DapperORM.Repositories.IDapperConnectRepository, DapperORM.Repositories.DapperConnectRepository>();
            return services;
        }

        public static IServiceCollection AddLibDapper(this IServiceCollection services,Action<DapperORM.Models.DapperORMConfigurationSettings> config)
        {
            services.AddTransient<DapperORM.Repositories.IDapperConnectRepository, DapperORM.Repositories.DapperConnectRepository>();
            config.Invoke(new DapperORM.Models.DapperORMConfigurationSettings());
            return services;
        }
    }
}
