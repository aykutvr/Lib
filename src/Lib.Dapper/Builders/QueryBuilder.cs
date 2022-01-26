using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Lib.DapperORM.Builders
{
    public class QueryBuilder : QueryParameterBuilder
    {
        internal string Query { get; set; }
        internal CommandType CommandType { get; set; } = CommandType.Text;
        public void SetQuery(string query)
        {
            Query = query;
        }
        public void SetCommandType(CommandType commandType)
        {
            CommandType = commandType;
        }
    }
}
