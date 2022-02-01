using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DapperORM.Repositories
{
    public interface IDapperMultipleQueryResultRepository
    {
        IDapperMultipleQueryResultRepository Read<T>(out List<T> result);
        List<T> Read<T>();
        IDapperMultipleQueryResultRepository Read<T1, T2, TReturn>(Func<T1, T2, TReturn> mappingFunc, string splitColumnNames, out List<TReturn> result);
        List<TReturn> Read<T1, T2, TReturn>(Func<T1, T2, TReturn> mappingFunc, string splitColumnNames);
        IDapperMultipleQueryResultRepository Read<T1, T2, T3, TReturn>(Func<T1, T2,T3, TReturn> mappingFunc, string splitColumnNames, out List<TReturn> result);
        List<TReturn> Read<T1, T2, T3, TReturn>(Func<T1, T2,T3, TReturn> mappingFunc, string splitColumnNames);
        IDapperMultipleQueryResultRepository Read<T1, T2, T3, T4, TReturn>(Func<T1, T2, T3, T4, TReturn> mappingFunc, string splitColumnNames, out List<TReturn> result);
        List<TReturn> Read<T1, T2, T3, T4, TReturn>(Func<T1, T2, T3, T4, TReturn> mappingFunc, string splitColumnNames);
        IDapperMultipleQueryResultRepository Read<T1, T2, T3, T4, T5, TReturn>(Func<T1, T2, T3, T4, T5, TReturn> mappingFunc, string splitColumnNames, out List<TReturn> result);
        List<TReturn> Read<T1, T2, T3, T4, T5, TReturn>(Func<T1, T2, T3, T4, T5, TReturn> mappingFunc, string splitColumnNames);
        IDapperMultipleQueryResultRepository Read<T1, T2, T3, T4, T5, T6, TReturn>(Func<T1, T2, T3, T4, T5, T6, TReturn> mappingFunc, string splitColumnNames, out List<TReturn> result);
        List<TReturn> Read<T1, T2, T3, T4, T5, T6, TReturn>(Func<T1, T2, T3, T4, T5, T6, TReturn> mappingFunc, string splitColumnNames);
        IDapperMultipleQueryResultRepository Read<T1, T2, T3, T4, T5, T6, T7, TReturn>(Func<T1, T2, T3, T4, T5, T6, T7, TReturn> mappingFunc, string splitColumnNames, out List<TReturn> result);
        List<TReturn> Read<T1, T2, T3, T4, T5, T6, T7, TReturn>(Func<T1, T2, T3, T4, T5, T6, T7, TReturn> mappingFunc, string splitColumnNames);
        IDapperMultipleQueryResultRepository ReadFirst<T>(out T result);
        T ReadFirst<T>();
        IDapperMultipleQueryResultRepository ReadFirstOrDefault<T>(out T result);
        T ReadFirstOrDefault<T>();
    }
}
