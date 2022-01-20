using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Logger.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddLibDapper(this IServiceCollection services)
        {
            services.AddTransient<DapperORM.Repositories.IDapperConnectRepository, DapperORM.Repositories.DapperConnectRepository>();
            services.AddTransient<Logger.Repositories.ILibLoggerRepository,Logger.Repositories.LibLoggerRepository>();
            return services;
        }

        public static IServiceCollection AddLibDapper(this IServiceCollection services, Action<Logger.Models.LoggerConfiguration> config)
        {
            services.AddTransient<DapperORM.Repositories.IDapperConnectRepository, DapperORM.Repositories.DapperConnectRepository>();
            services.AddTransient<Logger.Repositories.ILibLoggerRepository, Logger.Repositories.LibLoggerRepository>();
            config.Invoke(new Models.LoggerConfiguration());
            return services;
        }
    }
}
