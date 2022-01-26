using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static partial class Extensions
{
    public static void AddLibLocalizationWeb(this IServiceCollection services, Action<Lib.Localization.Web.Configuration.LibLocalizationConfigurator> config)
    {
        services.AddLibDapperCore();

        config.Invoke(new Lib.Localization.Web.Configuration.LibLocalizationConfigurator());

        services.AddSingleton<Lib.Localization.Repositories.ILibLanguageRepository, Lib.Localization.Repositories.LibLanguageRepository>();
        services.AddSingleton<Lib.Localization.Repositories.ILibLocalizationRepository,Lib.Localization.Repositories.LibLocalizationRepository>();

        Lib.Localization.Web.SharedSettings.DefaultLanguage = services.BuildServiceProvider().GetService<Lib.Localization.Repositories.ILibLanguageRepository>().GetDefault();
    }
}

