using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lib.Core.HtmlHelpers
{
    public partial class LibWidgetFactory : LibWidgetBuilder
    {
        public LibWidgetFactory(IHtmlHelper html) : base(html)
        {
        }
    }
}
