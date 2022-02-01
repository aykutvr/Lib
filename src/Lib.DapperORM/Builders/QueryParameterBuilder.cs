using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static Dapper.SqlMapper;

namespace Lib.DapperORM.Builders
{
    public class QueryParameterBuilder : IDisposable
    {
        internal DynamicParameters dynamicParameters { get; set; }


        public void AddParameter(string name, object value = null, DbType? dbType = null, ParameterDirection? direction = null, int? size = null, byte? precision = null, byte? scale = null)
        {
            dynamicParameters.Add(name, value, dbType, direction, size, precision, scale);
        }

        public void AddParameter(string name, object value, DbType? dbType, ParameterDirection? direction, int? size)
        {
            dynamicParameters.Add(name, value, dbType, direction, size);
        }
        public void AddParameter(object param) 
        {
            dynamicParameters.AddDynamicParams(param);
        }

        public void AddParameterIf(bool condition,string name, object value = null, DbType? dbType = null, ParameterDirection? direction = null, int? size = null, byte? precision = null, byte? scale = null)
        {
            if(condition)
                dynamicParameters.Add(name, value, dbType, direction, size, precision, scale);
        }

        public void AddParameterIf(bool condition, string name, object value, DbType? dbType, ParameterDirection? direction, int? size)
        {
            if(condition)
                dynamicParameters.Add(name, value, dbType, direction, size);
        }
        public void AddParameterIf(bool condition, object param)
        {
            if(condition)
                dynamicParameters.AddDynamicParams(param);
        }


        public void Dispose()
        {
            dynamicParameters = null;
        }
    }
}
