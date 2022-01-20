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
        bool Delete<T>(int id, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1) where T : class;
        bool Delete<T>(T data, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1) where T : class;
        bool DeleteAll<T>(CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1) where T : class;
        int Execute(string query, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        T ExecuteScalar<T>(string query, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        object ExecuteScalar(string query, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        TReturn Get<TReturn>(string query, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        TReturn Get<TReturn>(int id, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1) where TReturn : class;
        IDapperInsertRepository Insert([CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        IDictionary<string, List<Tuple<object, long, bool>>> Insert(Action<IDapperInsertRepository> config, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        T Insert<T>(T data, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1) where T : class;
        List<TReturn> List<TReturn>([CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1) where TReturn : class;
        List<TReturn> List<TReturn>(string query, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        List<TReturn> List<T1, T2, TReturn>(string query, Func<T1, T2, TReturn> map, string splitColumns, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        List<TReturn> List<T1, T2, T3, TReturn>(string query, Func<T1, T2, T3, TReturn> map, string splitColumns, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        List<TReturn> List<T1, T2, T3, T4, TReturn>(string query, Func<T1, T2, T3, T4, TReturn> map, string splitColumns, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        List<TReturn> List<T1, T2, T3, T4, T5, TReturn>(string query, Func<T1, T2, T3, T4, T5, TReturn> map, string splitColumns, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        List<TReturn> List<T1, T2, T3, T4, T5, T6, TReturn>(string query, Func<T1, T2, T3, T4, T5, T6, TReturn> map, string splitColumns, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        List<TReturn> List<T1, T2, T3, T4, T5, T6, T7, TReturn>(string query, Func<T1, T2, T3, T4, T5, T6, T7, TReturn> map, string splitColumns, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        IDapperMultipleQueryResultRepository Multiple(string query, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        bool Update<T>(T data, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1) where T : class;
        DataTable DataTable(string query, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        bool CreateOrAlterTable<T>();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
