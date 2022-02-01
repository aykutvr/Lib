using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.DapperORM.Attributes
{
    public class RelationshipAttribute : Attribute
    {
        public Lib.DapperORM.SQLRelationshipActions DeleteRule { get; set; } = SQLRelationshipActions.NoAction;
        public Lib.DapperORM.SQLRelationshipActions UpdateRule { get; set; } = SQLRelationshipActions.NoAction;

    }
}
