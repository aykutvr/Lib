using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DapperORM.Attributes
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = false,Inherited = true)]
    public class TableAttribute : Dapper.Contrib.Extensions.TableAttribute
    {
        public TableAttribute(string tableName) : base(tableName)
        {
        }
    }
}
