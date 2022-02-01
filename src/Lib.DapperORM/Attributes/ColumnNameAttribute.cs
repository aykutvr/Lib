using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.DapperORM.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ColumnNameAttribute : Attribute
    {
        public string ColumnName { get; set; } = string.Empty;
        public ColumnNameAttribute(string columnName)
        {
            ColumnName = columnName;
        }
    }
}
