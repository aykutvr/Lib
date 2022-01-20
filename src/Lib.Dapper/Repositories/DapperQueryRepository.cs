using Dapper;
using Dapper.Contrib.Extensions;
using Lib.DapperORM.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DapperORM.Repositories
{
    public class DapperQueryRepository : IDapperQueryRepository
    {
        public IDbConnection Connection { get; }

        public IDbTransaction? Transaction { get; }
        public DapperQueryRepository(IDbConnection connection)
        {
            Connection = connection;
            Transaction = null;
        }
        public DapperQueryRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            Connection = connection;
            Transaction = transaction;
        }
        private void AddLog(Exception ex, string? query = "", object? param = null, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {

        }

        public bool Delete<T>(int id, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            where T : class
        {
            try
            {
                return Connection.Delete(Get<T>(id, callerFilePath, callerMemberName, callerLineNumber), Transaction);
            }
            catch (Exception ex)
            {
                AddLog(ex, "", new { id }, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public bool Delete<T>(T data, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            where T : class
        {
            try
            {
                return Connection.Delete(data, Transaction);
            }
            catch (Exception ex)
            {
                AddLog(ex, "", data, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public bool DeleteAll<T>(CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            where T : class
        {
            try
            {
                return Connection.DeleteAll<T>();
            }
            catch (Exception ex)
            {
                AddLog(ex, "", null, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public int Execute(string query, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            try
            {
                return Connection.Execute(query, param, Transaction, null, commandType);
            }
            catch (Exception ex)
            {
                AddLog(ex, query, param, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public T ExecuteScalar<T>(string query, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            try
            {
                return Connection.ExecuteScalar<T>(query, param, Transaction, null, commandType);
            }
            catch (Exception ex)
            {
                AddLog(ex, query, param, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public object ExecuteScalar(string query, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            try
            {
                return Connection.ExecuteScalar(query, param, Transaction, null, commandType);
            }
            catch (Exception ex)
            {
                AddLog(ex, query, param, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public TReturn Get<TReturn>(string query, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            try
            {
                return Connection.QueryFirstOrDefault<TReturn>(query, param, Transaction, null, commandType);
            }
            catch (Exception ex)
            {
                AddLog(ex, query, param, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public TReturn Get<TReturn>(int id, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            where TReturn : class
        {
            try
            {
                return Connection.Get<TReturn>(id, Transaction);
            }
            catch (Exception ex)
            {
                AddLog(ex, "", new { id }, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public IDapperInsertRepository Insert([CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            try
            {
                return new DapperInsertRepository(Connection, Transaction);
            }
            catch (Exception ex)
            {
                AddLog(ex, "", "", callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }
        public T Insert<T>(T data, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            where T : class
        {
            try
            {
                return Get<T>(Convert.ToInt32(Connection.Insert(data, Transaction)), callerFilePath, callerMemberName, callerLineNumber);
            }
            catch (Exception ex)
            {
                AddLog(ex, "", data, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public List<TReturn> List<TReturn>([CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            where TReturn : class
        {
            try
            {
                return Connection.GetAll<TReturn>(Transaction).ToList();
            }
            catch (Exception ex)
            {
                AddLog(ex, "", null, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public List<TReturn> List<TReturn>(string query, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            try
            {
                return Connection.Query<TReturn>(query, param, Transaction, true, null, commandType).ToList();
            }
            catch (Exception ex)
            {
                AddLog(ex, query, param, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public List<TReturn> List<T1, T2, TReturn>(string query, Func<T1, T2, TReturn> map, string splitColumns, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            try
            {
                return Connection.Query(query, map, param, Transaction, true, splitColumns, null, commandType).ToList();
            }
            catch (Exception ex)
            {
                AddLog(ex, query, param, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public List<TReturn> List<T1, T2, T3, TReturn>(string query, Func<T1, T2, T3, TReturn> map, string splitColumns, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            try
            {
                return Connection.Query(query, map, param, Transaction, true, splitColumns, null, commandType).ToList();
            }
            catch (Exception ex)
            {
                AddLog(ex, query, param, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public List<TReturn> List<T1, T2, T3, T4, TReturn>(string query, Func<T1, T2, T3, T4, TReturn> map, string splitColumns, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            try
            {
                return Connection.Query(query, map, param, Transaction, true, splitColumns, null, commandType).ToList();

            }
            catch (Exception ex)
            {
                AddLog(ex, query, param, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public List<TReturn> List<T1, T2, T3, T4, T5, TReturn>(string query, Func<T1, T2, T3, T4, T5, TReturn> map, string splitColumns, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            try
            {
                return Connection.Query(query, map, param, Transaction, true, splitColumns, null, commandType).ToList();
            }
            catch (Exception ex)
            {
                AddLog(ex, query, param, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public List<TReturn> List<T1, T2, T3, T4, T5, T6, TReturn>(string query, Func<T1, T2, T3, T4, T5, T6, TReturn> map, string splitColumns, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            try
            {
                return Connection.Query(query, map, param, Transaction, true, splitColumns, null, commandType).ToList();

            }
            catch (Exception ex)
            {
                AddLog(ex, query, param, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public List<TReturn> List<T1, T2, T3, T4, T5, T6, T7, TReturn>(string query, Func<T1, T2, T3, T4, T5, T6, T7, TReturn> map, string splitColumns, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            try
            {
                return Connection.Query(query, map, param, Transaction, true, splitColumns, null, commandType).ToList();
            }
            catch (Exception ex)
            {
                AddLog(ex, query, param, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public IDapperMultipleQueryResultRepository Multiple(string query, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            try
            {
                var multipleResult = Connection.QueryMultiple(query, param, Transaction, null, commandType);
                IDapperMultipleQueryResultRepository multipleRepository = new DapperMultipleQueryResultRepository(multipleResult);
                return multipleRepository;

            }
            catch (Exception ex)
            {
                AddLog(ex, query, param, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public bool Update<T>(T data, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            where T : class
        {
            try
            {
                return Connection.Update(data, Transaction);
            }
            catch (Exception ex)
            {
                AddLog(ex, "", data, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public DataTable DataTable(string query, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            try
            {
                var dataReader = Connection.ExecuteReader(query, param, Transaction, null, commandType);
                DataTable dtable = new DataTable();
                dtable.Load(dataReader, LoadOption.OverwriteChanges);
                return dtable;
            }
            catch (Exception ex)
            {
                AddLog(ex, query, param, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public bool CreateOrAlterTable<T>()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, List<Tuple<object, long, bool>>> Insert(Action<IDapperInsertRepository> config, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            try
            {
                IDapperInsertRepository dapperInsertRepository = new DapperInsertRepository(Connection,Transaction);
                config.Invoke(dapperInsertRepository);
                return dapperInsertRepository.GetResult();
            }
            catch (Exception ex)
            {
                AddLog(ex, null, null, callerFilePath, callerMemberName, callerLineNumber);
                throw;
            }
        }

        public void CommitTransaction()
        {
            if (Transaction != null)
            {

                Transaction.Commit();
                Transaction.Dispose();
            }

            CloseConnection();
        }

        public void RollbackTransaction()
        {
            if (Transaction != null)
            {

                Transaction.Rollback();
                Transaction.Dispose();
            }


            CloseConnection();
        }
        public void CloseConnection()
        {

            if (Transaction == null && Connection != null && Connection.State != ConnectionState.Closed)
            {
                Connection.Close();
                Connection.Dispose();
            }
        }

        public void Dispose()
        {
            Transaction?.Dispose();
            Connection.Dispose();
        }
    }
}
