using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    public static Lib.DapperORM.Repositories.IDapperConnectRepository Dapper(this Lib.Core.Web.Factories.LibControllerWidgetFactory wFactory)
    {
        return new Lib.DapperORM.Repositories.DapperConnectRepository();
    }
}
