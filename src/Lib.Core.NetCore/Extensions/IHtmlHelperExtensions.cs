using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static partial class IHtmlHelperExtensions
{
    public static Lib.Core.NetCore.HtmlHelpers.LibWidgetFactory Lib(this IHtmlHelper html) => new Lib.Core.NetCore.HtmlHelpers.LibWidgetFactory(html);
}
