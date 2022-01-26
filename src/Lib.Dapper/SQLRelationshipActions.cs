using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.DapperORM
{
    public enum SQLRelationshipActions
    {
        [Attributes.RelastionshipRules(RelastionshipRuleText = "NO ACTION")]
        NoAction,
        [Attributes.RelastionshipRules(RelastionshipRuleText = "CASCADE")]
        Cascade,
        [Attributes.RelastionshipRules(RelastionshipRuleText = "SET NULL")]
        SetNull,
        [Attributes.RelastionshipRules(RelastionshipRuleText = "SET DEFAULT")]
        SetDefault
    }
}
