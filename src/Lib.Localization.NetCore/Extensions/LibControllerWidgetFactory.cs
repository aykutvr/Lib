using Lib.Localization.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public static partial class Extensions
{
    public static string Lang(this Lib.Core.Web.Factories.LibControllerWidgetFactory wFactory, string key, params string[] args)
    {
        return Lang(key, args);
    }
}