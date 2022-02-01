using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.DapperORM.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class CollateAttribute : Attribute
    {
        public Lib.DapperORM.SQLCollateTypes CollateType { get; set; }
        public CollateAttribute(Lib.DapperORM.SQLCollateTypes collateType)
        {
            CollateType = collateType;
        }



    }
}