using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace Lib.DapperORM.Repositories
{
    public class DapperInsertRepository : IDapperInsertRepository, IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; }
        internal IDictionary<string, List<Tuple<object, long, bool>>> dicResult { get; set; }
        public DapperInsertRepository(IDbConnection connection)
        {
            Connection = connection;
            Transaction = null;
            dicResult = new Dictionary<string, List<Tuple<object, long, bool>>>();
        }
        public DapperInsertRepository(IDbConnection connection, IDbTransaction transaction)
        {
            Connection = connection;
            Transaction = transaction;
            dicResult = new Dictionary<string, List<Tuple<object, long, bool>>>();
        }

        private void AddLog(Exception ex, string query = "", object param = null, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {

        }
        public IDapperInsertRepository AddData<T>(T data, out T resultData, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            where T : class
        {
            try
            {
                long insertResult = Connection.Insert<T>(data, Transaction);
                resultData = data;
                dicResult.AddIfNotContainsKey(typeof(T).Name, new List<Tuple<object, long, bool>>());
                dicResult[nameof(T)].Add(new Tuple<object, long, bool>(data, insertResult, true));
                return this;
            }
            catch (Exception ex)
            {
                AddLog(ex, "", data, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }


        }

        public IDapperInsertRepository AddData<T>(T data, out long resultData, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            where T : class
        {
            try
            {
                long insertResult = Connection.Insert<T>(data, Transaction);
                resultData = insertResult;
                dicResult.AddIfNotContainsKey(nameof(T), new List<Tuple<object, long, bool>>());
                dicResult[nameof(T)].Add(new Tuple<object, long, bool>(data, insertResult, true));
                return this;
            }
            catch (Exception ex)
            {
                AddLog(ex, "", data, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public IDapperInsertRepository AddData<T>(List<T> data, out List<long> resultData, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            where T : class
        {
            try
            {
                resultData = new List<long>();
                foreach (var item in data)
                {
                    long insertResult = Connection.Insert<T>(item, Transaction);
                    resultData.Add(insertResult);
                    dicResult.AddIfNotContainsKey(nameof(T), new List<Tuple<object, long, bool>>());
                    dicResult[nameof(T)].Add(new Tuple<object, long, bool>(item, insertResult, true));
                }

                return this;
            }
            catch (Exception ex)
            {
                AddLog(ex, "", data, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public IDapperInsertRepository AddData<T>(List<T> data, out List<T> resultData, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            where T : class
        {
            try
            {
                resultData = new List<T>();
                foreach (var item in data)
                {
                    long insertResult = Connection.Insert<T>(item, Transaction);
                    resultData.Add(item);
                    dicResult.AddIfNotContainsKey(nameof(T), new List<Tuple<object, long, bool>>());
                    dicResult[nameof(T)].Add(new Tuple<object, long, bool>(item, insertResult, true));
                }

                return this;
            }
            catch (Exception ex)
            {
                AddLog(ex, "", data, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public IDapperInsertRepository AddData<T>(T data, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            where T : class
        {
            try
            {
                long insertResult = Connection.Insert<T>(data, Transaction);
                dicResult.AddIfNotContainsKey(nameof(T), new List<Tuple<object, long, bool>>());
                dicResult[nameof(T)].Add(new Tuple<object, long, bool>(data, insertResult, true));
                return this;
            }
            catch (Exception ex)
            {
                AddLog(ex, "", data, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public IDapperInsertRepository AddData<T>(List<T> data, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            where T : class
        {
            try
            {
                foreach (var item in data)
                {
                    long insertResult = Connection.Insert<T>(item, Transaction);
                    dicResult.AddIfNotContainsKey(nameof(T), new List<Tuple<object, long, bool>>());
                    dicResult[nameof(T)].Add(new Tuple<object, long, bool>(item, insertResult, true));
                }

                return this;
            }
            catch (Exception ex)
            {
                AddLog(ex, "", data, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public IDictionary<string, List<Tuple<object, long, bool>>> GetResult()
        {
            return dicResult;
        }

        public void Dispose()
        {
            dicResult.Clear();
        }
    }
}
