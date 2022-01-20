using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Core.Extensions
{
    public static partial class IHtmlHelperExtensions
    {
        public static HtmlHelpers.LibWidgetFactory Lib(this IHtmlHelper html) => new HtmlHelpers.LibWidgetFactory(html);
    }
}
