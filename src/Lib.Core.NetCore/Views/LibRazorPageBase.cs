using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Core.Web.Views
{
    public abstract class LibRazorPageBase<TModel> : RazorPage<TModel>
    {
        public virtual string Test()
        {
            return "";
        }
    }
}
