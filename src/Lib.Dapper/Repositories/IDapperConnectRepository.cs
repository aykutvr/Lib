using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DapperORM.Repositories
{
    public interface IDapperConnectRepository : IDisposable
    {
        IDapperQueryRepository Connect(string connectionString, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        IDapperQueryRepository Connect(string connectionString, bool withTransaction, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        IDapperQueryRepository Connect(string connectionString, IDbTransaction transaction, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        IDapperQueryRepository Connect(IDbConnection connection, IDbTransaction transaction, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        void Connect(string connectionString, Action<IDapperQueryRepository> queryActions, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        void Connect(string connectionString, bool withTransaction, Action<IDapperQueryRepository> queryActions, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        void Connect(string connectionString, IDbTransaction transaction, Action<IDapperQueryRepository> queryActions, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        void Connect(IDbConnection connection, IDbTransaction transaction, Action<IDapperQueryRepository> queryActions, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);

    }
}
