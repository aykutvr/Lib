using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Core.Web.Widgets
{
    public class LibWidgetBuilder
    {
        protected IHtmlHelper htmlHelper { get; set; }
        public LibWidgetBuilder(IHtmlHelper html) => this.htmlHelper = html;
    }
}
