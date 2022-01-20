using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DapperORM.Repositories
{
    public interface IDapperQueryRepository : IDisposable
    {
        public bool Delete<T>(int id, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1) where T : class;
        public bool Delete<T>(T data, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1) where T : class;
        public bool DeleteAll<T>(CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1) where T : class;
        public int Execute(string query, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        public T ExecuteScalar<T>(string query, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        public object ExecuteScalar(string query, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        public TReturn Get<TReturn>(string query, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        public TReturn Get<TReturn>(int id, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1) where TReturn : class;
        public IDapperInsertRepository Insert([CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        public Dictionary<string, List<Tuple<object, long, bool>>> Insert(Action<IDapperInsertRepository> config, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        public T Insert<T>(T data, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1) where T : class;
        public List<TReturn> List<TReturn>([CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1) where TReturn : class;
        public List<TReturn> List<TReturn>(string query, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        public List<TReturn> List<T1, T2, TReturn>(string query, Func<T1, T2, TReturn> map, string splitColumns, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        public List<TReturn> List<T1, T2, T3, TReturn>(string query, Func<T1, T2, T3, TReturn> map, string splitColumns, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        public List<TReturn> List<T1, T2, T3, T4, TReturn>(string query, Func<T1, T2, T3, T4, TReturn> map, string splitColumns, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        public List<TReturn> List<T1, T2, T3, T4, T5, TReturn>(string query, Func<T1, T2, T3, T4, T5, TReturn> map, string splitColumns, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        public List<TReturn> List<T1, T2, T3, T4, T5, T6, TReturn>(string query, Func<T1, T2, T3, T4, T5, T6, TReturn> map, string splitColumns, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        public List<TReturn> List<T1, T2, T3, T4, T5, T6, T7, TReturn>(string query, Func<T1, T2, T3, T4, T5, T6, T7, TReturn> map, string splitColumns, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        public IDapperMultipleQueryResultRepository Multiple(string query, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        public bool Update<T>(T data, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1) where T : class;
        public DataTable DataTable(string query, object? param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        public bool CreateOrAlterTable<T>();
        public void CommitTransaction();
        public void RollbackTransaction();
    }
}
