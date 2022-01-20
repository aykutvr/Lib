using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

public static partial class LibWidgetFactory
{
    public static Lib.Core.Web.Widgets.LibWidgetFactory Lib(this IHtmlHelper html) => new Lib.Core.Web.Widgets.LibWidgetFactory(html);
}
