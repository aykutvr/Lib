using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.DapperORM.Attributes
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = false,Inherited = true)]
    public class SchemaAttribute :Attribute
    {
        public string SchemaName { get; set; }
        public SchemaAttribute(string schemaName)
        {
            SchemaName = schemaName;
        }
    }
}
