using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DapperORM.Repositories
{
    public class DapperMultipleQueryResultRepository : IDapperMultipleQueryResultRepository
    {
        Dapper.SqlMapper.GridReader GridReader { get; set; }
        public DapperMultipleQueryResultRepository(Dapper.SqlMapper.GridReader gridReader)
        {
            GridReader = gridReader;
        }
        public IDapperMultipleQueryResultRepository Read<T>(out List<T> result)
        {
            result = Read<T>();
            return this;
        }
        public IDapperMultipleQueryResultRepository ReadFirst<T>(out T result)
        {
            result = ReadFirst<T>();
            return this;
        }
        public IDapperMultipleQueryResultRepository ReadFirstOrDefault<T>(out T result)
        {
            result = ReadFirstOrDefault<T>();
            return this;
        }
        public List<T> Read<T>()
        {
            return GridReader.Read<T>(true).ToList();
        }
        public void Read <T>(Action<IDapperMultipleQueryResultRepository> reader)
        {
            reader.Invoke(this);
        }
        public T ReadFirst<T>()
        {
            return GridReader.ReadFirst<T>();
        }
        public T ReadFirstOrDefault<T>()
        {
            return GridReader.ReadFirstOrDefault<T>();
        }
        public IDapperMultipleQueryResultRepository Read<T1, T2, TReturn>(Func<T1, T2, TReturn> mappingFunc, string splitColumnNames, out List<TReturn> result)
        {
            result = Read(mappingFunc, splitColumnNames);
            return this;
        }
        public List<TReturn> Read<T1, T2, TReturn>(Func<T1, T2, TReturn> mappingFunc, string splitColumnNames)
        {
            return GridReader.Read(mappingFunc, splitColumnNames, true).ToList();
        }
        public IDapperMultipleQueryResultRepository Read<T1, T2, T3, TReturn>(Func<T1, T2, T3, TReturn> mappingFunc, string splitColumnNames, out List<TReturn> result)
        {
            result = Read(mappingFunc, splitColumnNames);
            return this;
        }
        public List<TReturn> Read<T1, T2, T3, TReturn>(Func<T1, T2, T3, TReturn> mappingFunc, string splitColumnNames)
        {
            return GridReader.Read(mappingFunc, splitColumnNames, true).ToList();
        }
        public IDapperMultipleQueryResultRepository Read<T1, T2, T3, T4, TReturn>(Func<T1, T2, T3, T4, TReturn> mappingFunc, string splitColumnNames, out List<TReturn> result)
        {
            result = Read(mappingFunc, splitColumnNames);
            return this;
        }
        public List<TReturn> Read<T1, T2, T3, T4, TReturn>(Func<T1, T2, T3, T4, TReturn> mappingFunc, string splitColumnNames)
        {
            return GridReader.Read(mappingFunc, splitColumnNames, true).ToList();
        }
        public IDapperMultipleQueryResultRepository Read<T1, T2, T3, T4, T5, TReturn>(Func<T1, T2, T3, T4, T5, TReturn> mappingFunc, string splitColumnNames, out List<TReturn> result)
        {
            result = Read(mappingFunc, splitColumnNames);
            return this;
        }
        public List<TReturn> Read<T1, T2, T3, T4, T5, TReturn>(Func<T1, T2, T3, T4, T5, TReturn> mappingFunc, string splitColumnNames)
        {
            return GridReader.Read(mappingFunc, splitColumnNames, true).ToList();
        }
        public IDapperMultipleQueryResultRepository Read<T1, T2, T3, T4, T5, T6, TReturn>(Func<T1, T2, T3, T4, T5, T6, TReturn> mappingFunc, string splitColumnNames, out List<TReturn> result)
        {
            result = Read(mappingFunc, splitColumnNames);
            return this;
        }
        public List<TReturn> Read<T1, T2, T3, T4, T5, T6, TReturn>(Func<T1, T2, T3, T4, T5, T6, TReturn> mappingFunc, string splitColumnNames)
        {
            return GridReader.Read(mappingFunc, splitColumnNames, true).ToList();
        }
        public IDapperMultipleQueryResultRepository Read<T1, T2, T3, T4, T5, T6, T7, TReturn>(Func<T1, T2, T3, T4, T5, T6, T7, TReturn> mappingFunc, string splitColumnNames, out List<TReturn> result)
        {
            result = Read(mappingFunc, splitColumnNames);
            return this;
        }
        public List<TReturn> Read<T1, T2, T3, T4, T5, T6, T7, TReturn>(Func<T1, T2, T3, T4, T5, T6, T7, TReturn> mappingFunc, string splitColumnNames)
        {
            return GridReader.Read(mappingFunc, splitColumnNames, true).ToList();
        }
    }
}
