using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    public static Lib.Core.Web.Factories.LibRazorWidgetFactory LibWidgets(this IHtmlHelper html) => new Lib.Core.Web.Factories.LibRazorWidgetFactory(html);
}
