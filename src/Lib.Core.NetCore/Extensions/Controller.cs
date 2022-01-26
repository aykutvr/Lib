using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    public static Lib.Core.Web.Factories.LibControllerWidgetFactory LibWidgets(this Controller @this)
    {
        Lib.Core.Web.Factories.LibControllerWidgetFactory libFactory = new Lib.Core.Web.Factories.LibControllerWidgetFactory();
        libFactory.Ctrl = @this;
        return libFactory;
    }
}
