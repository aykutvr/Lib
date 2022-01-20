using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public static partial class Extensions
    {
        public static Lib.DapperORM.Repositories.IDapperConnectRepository Dapper(this Lib.DapperORM.IDapper @this)
        {
            return new Lib.DapperORM.Repositories.DapperConnectRepository();
        }
    }
