using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static partial class Extensions
{
    public static IServiceCollection AddLibDapperCore(this IServiceCollection services)
    {
        services.AddTransient<Lib.DapperORM.Repositories.IDapperConnectRepository, Lib.DapperORM.Repositories.DapperConnectRepository>();
        return services;
    }

    public static IServiceCollection AddLibDapperCore(this IServiceCollection services,Action<Lib.DapperORM.Models.DapperORMConfigurationSettings> config)
    {
        services.AddTransient<Lib.DapperORM.Repositories.IDapperConnectRepository, Lib.DapperORM.Repositories.DapperConnectRepository>();
        config.Invoke(new Lib.DapperORM.Models.DapperORMConfigurationSettings());
        return services;
    }


}
