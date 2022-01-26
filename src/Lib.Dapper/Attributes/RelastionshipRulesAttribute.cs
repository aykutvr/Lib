using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.DapperORM.Attributes
{
    [AttributeUsage(AttributeTargets.Field,AllowMultiple = false,Inherited = true)]
    public class RelastionshipRulesAttribute : Attribute
    {
        public string RelastionshipRuleText { get; set; } = "";

    }
}
