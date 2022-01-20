﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Core.HtmlHelpers
{
    public class LibWidgetBuilder
    {
        protected IHtmlHelper htmlHelper { get; set; }
        public LibWidgetBuilder(IHtmlHelper html) => this.htmlHelper = html;
    }
}
