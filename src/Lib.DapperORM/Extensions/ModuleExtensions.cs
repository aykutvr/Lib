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

        public static string GetSQLText(this Lib.DapperORM.SQLRelationshipActions @this)
        {
            var attr = @this.GetType().GetField(@this.ToString()).GetCustomAttributes(typeof(Lib.DapperORM.Attributes.RelastionshipRulesAttribute), false).FirstOrDefault() as Lib.DapperORM.Attributes.RelastionshipRulesAttribute;
            return attr.RelastionshipRuleText;
        }
    }
