using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DapperORM.Repositories
{
    public class DapperConnectRepository : IDapperConnectRepository
    {
        public IDapperQueryRepository Connect()
        {
            return Connect(connectionString: SharedSettings.ConnectionString, transaction: null);
        }
        public void Connect(bool withTransaction, Action<IDapperQueryRepository> queryActions)
            => Connect(SharedSettings.ConnectionString, withTransaction, queryActions);
        public void Connect( Action<IDapperQueryRepository> queryActions)
            => Connect(SharedSettings.ConnectionString, true, queryActions);
        public IDapperQueryRepository Connect(string connectionString, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            return Connect(connectionString : connectionString,transaction: null, callerFilePath, callerMemberName, callerLineNumber);
        }

        public IDapperQueryRepository Connect(string connectionString, bool withTransaction, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            IDbTransaction transaction = connection.BeginTransaction();
            return Connect(connection, transaction, callerFilePath, callerMemberName, callerLineNumber);
            
        }

        public IDapperQueryRepository Connect(string connectionString, IDbTransaction transaction, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            return Connect(new SqlConnection(connectionString), transaction, callerFilePath, callerMemberName, callerLineNumber);
        }

        public IDapperQueryRepository Connect(IDbConnection connection, IDbTransaction transaction, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            return new DapperQueryRepository(connection, transaction);
        }

        public void Connect(string connectionString, Action<IDapperQueryRepository> queryActions, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            Connect(new SqlConnection(connectionString), null, queryActions, callerFilePath, callerMemberName, callerLineNumber);
        }

        public void Connect(string connectionString, bool withTransaction, Action<IDapperQueryRepository> queryActions, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            IDbTransaction transaction = connection.BeginTransaction();
            Connect(connection, transaction, queryActions, callerFilePath, callerMemberName, callerLineNumber);
            
        }
        public void Connect(string connectionString, IDbTransaction transaction, Action<IDapperQueryRepository> queryActions, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            => Connect(new SqlConnection(connectionString), transaction, queryActions, callerFilePath, callerMemberName, callerLineNumber);
        public void Connect(IDbConnection connection, IDbTransaction transaction, Action<IDapperQueryRepository> queryActions, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            using(IDapperQueryRepository query = new DapperQueryRepository(connection,transaction))
            {
                queryActions.Invoke(query);
                if (transaction != null)
                    transaction.Commit();
            }
        }
        
        public void Dispose()
        {
        }
    }
}
