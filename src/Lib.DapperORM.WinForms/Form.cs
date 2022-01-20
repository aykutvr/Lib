using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    public static Lib.DapperORM.Repositories.IDapperConnectRepository Dapper(this System.Windows.Forms.Form @this)
    {
        return new Lib.DapperORM.Repositories.DapperConnectRepository();
    }
}
