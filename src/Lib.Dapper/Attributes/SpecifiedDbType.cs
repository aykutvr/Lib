using System;

namespace Lib.DapperORM.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class SpecifiedDbType : Attribute
    {
        public System.Data.SqlDbType DbType { get; set; }
        public SpecifiedDbType(System.Data.SqlDbType dbtype)
        {
            DbType = dbtype;
        }
    }
}