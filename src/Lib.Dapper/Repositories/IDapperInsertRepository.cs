using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DapperORM.Repositories
{
    public interface IDapperInsertRepository
    {
        public IDapperInsertRepository AddData<T>(T data, out T resultData, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1) where T : class;
        public IDapperInsertRepository AddData<T>(T data, out long resultData, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1) where T : class;
        public IDapperInsertRepository AddData<T>(List<T> data, out List<long> resultData, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1) where T : class;
        public IDapperInsertRepository AddData<T>(List<T> data, out List<T> resultData, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1) where T : class;
        public IDapperInsertRepository AddData<T>(T data, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1) where T : class;
        public IDapperInsertRepository AddData<T>(List<T> data, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1) where T : class;
        public Dictionary<string, List<Tuple<object, long, bool>>> GetResult();
    }
}
