using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static partial class LibWidgetFactory
{
    public static Lib.DataTablesNet.Builders.GridBuilder<T> DataTable<T>(this Lib.Core.Web.Widgets.LibWidgetFactory @this) where T : class => new Lib.DataTablesNet.Builders.GridBuilder<T>();
}
