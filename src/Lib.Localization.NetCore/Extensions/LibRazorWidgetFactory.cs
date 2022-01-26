using Lib.Localization.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;
using Microsoft.Extensions.Primitives;

public static partial class Extensions
{
    private static string Lang(string key, params string[] args)
    {
        Lib.Localization.Repositories.ILibLocalizationRepository localization = Lib.Core.Web.SharedSettings.ServiceProvider.GetService<ILibLocalizationRepository>();
        Lib.Localization.Repositories.ILibLanguageRepository language = Lib.Core.Web.SharedSettings.ServiceProvider.GetService<ILibLanguageRepository>();
        IHttpContextAccessor contextAccessor = Lib.Core.Web.SharedSettings.ServiceProvider.GetService<IHttpContextAccessor>();

        if (localization.IsNull())
            return "";

        if (contextAccessor.IsNull())
            return "";

        string activeLang = "";
        if (contextAccessor.HttpContext.Request.Headers.TryGetValue("Content-Language", out StringValues langString))
        {
            activeLang = langString.ToString();
        }
        else
        {
            activeLang = Lib.Localization.Web.SharedSettings.DefaultLanguage.Name;
        }

        var localeData = localization.List(config =>
        {
            config.SetKey(key);
            config.SetLanguage(activeLang);
        });

        if (localeData == null || !localeData.Any())
        {
            localization.Insert(new Lib.Localization.Dto.LocalizationDto
            {
                KeyString = key,
                LanguageId = Lib.Localization.Web.SharedSettings.DefaultLanguage.Id,
                SourcePath = "",
                ValueString = key
            });
            if (activeLang == Lib.Localization.Web.SharedSettings.DefaultLanguage.Name)
                return String.Format(key, args);
            else
                return $"[{String.Format(key, args)}]";

        }
        else if (localeData.Any(a => a.Language.Name == activeLang))
            return String.Format(localeData.First(f => f.Language.Name == activeLang).ValueString, args);
        else
            return $"[{String.Format(key, args)}]";
    }
    public static string Lang(this Lib.Core.Web.Views.LibRazorPageBase<dynamic> @this, string key, params string[] args)
    {
        return Lang(key,args);
    }
    public static string Lang(this Lib.Core.Web.Factories.LibRazorWidgetFactory @this,string key,params string[] args)
    {
        return Lang(key, args);
    }
}

