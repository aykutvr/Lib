using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    public static void AddLibCoreWeb(this IServiceCollection @this)
    {
        Lib.Core.Web.SharedSettings.ServiceProvider = @this.BuildServiceProvider();
    }
}