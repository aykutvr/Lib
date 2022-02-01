using Dapper;
using Dapper.Contrib.Extensions;
using Lib.DapperORM.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DapperORM.Repositories
{
    public class DapperQueryRepository : IDapperQueryRepository
    {
        public IDbConnection Connection { get; }

        public IDbTransaction Transaction { get; }
        public DapperQueryRepository(IDbConnection connection)
        {
            Connection = connection;
            Transaction = null;
        }
        public DapperQueryRepository(IDbConnection connection, IDbTransaction transaction)
        {
            Connection = connection;
            Transaction = transaction;
        }
        private void AddLog(Exception ex, string query = "", object param = null, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
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

        public int Execute(string query, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
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

        public T ExecuteScalar<T>(string query, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
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

        public object ExecuteScalar(string query, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
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

        public TReturn Get<TReturn>(string query, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
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

        public List<TReturn> ListAll<TReturn>([CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
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

        public List<TReturn> List<TReturn>(string query, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
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
        public List<TReturn> List<TReturn>(string query, Action<Builders.QueryParameterBuilder> pBuilder, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            using (Builders.QueryParameterBuilder builder = new Builders.QueryParameterBuilder())
            {
                try
                {
                    pBuilder.Invoke(builder);
                    return Connection.Query<TReturn>(query, builder.dynamicParameters, Transaction, true, null, commandType).ToList();
                }
                catch (Exception ex)
                {
                    AddLog(ex, query, builder.dynamicParameters, callerFilePath, callerMemberName, callerLineNumber);
                    throw;
                }
            }
        }
        public List<TReturn> List<TReturn>(Action<Builders.QueryBuilder> qBuilder, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            using (Builders.QueryBuilder builder = new Builders.QueryBuilder())
            {
                try
                {
                    qBuilder.Invoke(builder);
                    return Connection.Query<TReturn>(builder.Query, builder.dynamicParameters, Transaction, true, null, builder.CommandType).ToList();
                }
                catch (Exception ex)
                {
                    AddLog(ex, builder.Query, builder.dynamicParameters, callerFilePath, callerMemberName, callerLineNumber);
                    throw;
                }
            }
        }

        public List<TReturn> List<T1, T2, TReturn>(string query, Func<T1, T2, TReturn> map, string splitColumns, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
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
        public List<TReturn> List<T1, T2, TReturn>(string query, Func<T1, T2, TReturn> map, string splitColumns, Action<Builders.QueryParameterBuilder> pBuilder, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            using (Builders.QueryParameterBuilder builder = new Builders.QueryParameterBuilder())
            {
                pBuilder.Invoke(builder);
                try
                {
                    return Connection.Query(query, map, builder.dynamicParameters, Transaction, true, splitColumns, null, commandType).ToList();
                }
                catch (Exception ex)
                {
                    AddLog(ex, query, builder.dynamicParameters, callerFilePath, callerMemberName, callerLineNumber);
                    throw;
                }
            }
            
        }
        public List<TReturn> List<T1, T2, TReturn>(Action<Builders.QueryBuilder> qBuilder, Func<T1, T2, TReturn> map, string splitColumns,  [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            using (Builders.QueryBuilder builder = new Builders.QueryBuilder())
            {
                qBuilder.Invoke(builder);
                try
                {
                    return Connection.Query(builder.Query, map, builder.dynamicParameters, Transaction, true, splitColumns, null, builder.CommandType).ToList();
                }
                catch (Exception ex)
                {
                    AddLog(ex, builder.Query, builder.dynamicParameters, callerFilePath, callerMemberName, callerLineNumber);
                    throw;
                }
            }

        }

        public List<TReturn> List<T1, T2, T3, TReturn>(string query, Func<T1, T2, T3, TReturn> map, string splitColumns, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
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

        public List<TReturn> List<T1, T2, T3, T4, TReturn>(string query, Func<T1, T2, T3, T4, TReturn> map, string splitColumns, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
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

        public List<TReturn> List<T1, T2, T3, T4, T5, TReturn>(string query, Func<T1, T2, T3, T4, T5, TReturn> map, string splitColumns, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
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

        public List<TReturn> List<T1, T2, T3, T4, T5, T6, TReturn>(string query, Func<T1, T2, T3, T4, T5, T6, TReturn> map, string splitColumns, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
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

        public List<TReturn> List<T1, T2, T3, T4, T5, T6, T7, TReturn>(string query, Func<T1, T2, T3, T4, T5, T6, T7, TReturn> map, string splitColumns, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
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

        public IDapperMultipleQueryResultRepository Multiple(string query, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
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

        public DataTable DataTable(string query, object param = null, CommandType commandType = CommandType.Text, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
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
        private class SQLTableDefinition
        {
            public SQLTableDefinition(Type typ)
            {
                TableName = typ.Name;
                foreach (var item in typ.GetCustomAttributes(true))
                {
                    if (item.GetType() == typeof(Dapper.Contrib.Extensions.TableAttribute))
                        TableName = ((Dapper.Contrib.Extensions.TableAttribute)item).Name;
                    else if (item.GetType() == typeof(DapperORM.Attributes.TableAttribute))
                        TableName = ((DapperORM.Attributes.TableAttribute)item).Name;
                    else if (item.GetType() == typeof(DapperORM.Attributes.SchemaAttribute))
                        Schema = ((DapperORM.Attributes.SchemaAttribute)item).SchemaName;
                }

                Columns = typ.GetProperties().Select(s=> new SQLColumnDefinition(s)).ToList();
            }
            public string Schema { get; set; } = "dbo";
            public string TableName { get; set; } = string.Empty;
            public bool TableExists { get; set; } = false;
            public List<SQLColumnDefinition> Columns { get; set; } = new List<SQLColumnDefinition>();

        }
        private class SQLColumnDefinition
        {
            public SQLColumnDefinition(PropertyInfo column)
            {
                ColumnName = column.Name;
                IsNullable = column.PropertyType.IsGenericType && column.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>);
                IsEnum = column.PropertyType.IsEnum;
                ColumnType = new Func<Type>(() =>
                {
                    if (IsNullable)
                        if (IsEnum)
                            return Nullable.GetUnderlyingType(Enum.GetUnderlyingType(column.PropertyType));
                        else
                            return Nullable.GetUnderlyingType(column.PropertyType);
                    else if (IsEnum)
                        return Enum.GetUnderlyingType(column.PropertyType);
                    else
                        return column.PropertyType;
                }).Invoke();

                PropertyInfo nestedDto = column.PropertyType.GetProperties().Where(w =>
                                                                                        w.GetCustomAttributes(typeof(Dapper.Contrib.Extensions.KeyAttribute), true).Any() ||
                                                                                        w.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.KeyAttribute), true).Any() ||
                                                                                        w.GetCustomAttributes(typeof(Attributes.KeyAttribute), true).Any() ||
                                                                                        w.GetCustomAttributes(typeof(Dapper.Contrib.Extensions.ExplicitKeyAttribute), true).Any()).FirstOrDefault();
                if (nestedDto != null)
                {
                    RelationalField = new SQLRelationalColumnDefinition(column.PropertyType);
                    RelationalField.RelationalColumnName = ColumnName + RelationalField.RelationalKeyColumn.ColumnName;
                    if(column.GetCustomAttribute(typeof(Attributes.RelationshipAttribute),true) != null)
                    {
                        RelationalField.RelationProperties = column.GetCustomAttribute<Attributes.RelationshipAttribute>(true);
                    }
                }
                else
                {
                    Dictionary<Type, string> typeMap = new Dictionary<Type, string>();
                    typeMap.Add(typeof(string), "varchar");
                    typeMap.Add(typeof(int), "int");
                    typeMap.Add(typeof(long), "bigint");
                    typeMap.Add(typeof(byte), "tinyint");
                    typeMap.Add(typeof(double), "float");
                    typeMap.Add(typeof(float), "float");
                    typeMap.Add(typeof(byte[]), "image");
                    typeMap.Add(typeof(DateTime), "datetime");
                    typeMap.Add(typeof(short), "smallint");
                    typeMap.Add(typeof(Guid), "uniqueidentifier");
                    typeMap.Add(typeof(bool), "bit");
                    typeMap.Add(typeof(Nullable<int>), "int");
                    typeMap.Add(typeof(Nullable<long>), "bigint");
                    typeMap.Add(typeof(Nullable<byte>), "tinyint");
                    typeMap.Add(typeof(Nullable<double>), "float");
                    typeMap.Add(typeof(Nullable<float>), "float");
                    typeMap.Add(typeof(Nullable<DateTime>), "datetime");
                    typeMap.Add(typeof(Nullable<short>), "smallint");
                    typeMap.Add(typeof(Nullable<Guid>), "uniqueidentifier");
                    typeMap.Add(typeof(Nullable<bool>), "bit");

                    SpecifiedDbType = typeMap[ColumnType].SqlTypeNameToSqlDbType();
                    if (SpecifiedDbType == SqlDbType.VarChar)
                        StringLength = 50;
                }
               


                foreach (var attr in column.GetCustomAttributes(true))
                {
                    if (attr.IsTypeOf(typeof(Attributes.CollateAttribute)))
                        CollateType = attr.As<Attributes.CollateAttribute>().CollateType;
                    if (attr.IsTypeOf(typeof(Attributes.SpecifiedDbType)))
                        SpecifiedDbType = attr.As<Attributes.SpecifiedDbType>().DbType;
                    else if (attr.IsTypeOf(typeof(Attributes.ColumnNameAttribute)))
                        ColumnName = attr.As<Attributes.ColumnNameAttribute>().ColumnName.IfEmpty(column.Name);
                    else if (attr.IsTypeOf(typeof(Attributes.MaskedWithAttribute)))
                        MaskedWith = attr.As<Attributes.MaskedWithAttribute>().FunctionName;
                    else if (attr.IsTypeOf(typeof(System.ComponentModel.DataAnnotations.MaxLengthAttribute)))
                        StringLength = attr.As<System.ComponentModel.DataAnnotations.MaxLengthAttribute>().Length;
                    else if (attr.IsTypeOf(typeof(System.ComponentModel.DataAnnotations.StringLengthAttribute)))
                        StringLength = attr.As<System.ComponentModel.DataAnnotations.StringLengthAttribute>().MaximumLength;
                    else if (attr.IsTypeOf(typeof(System.ComponentModel.DataAnnotations.KeyAttribute)))
                    {
                        PrimaryKey = true;
                        Identity.Enabled = true;
                    }
                    else if (attr.IsTypeOf(typeof(Dapper.Contrib.Extensions.KeyAttribute)))
                    {
                        PrimaryKey = true;
                        Identity.Enabled = true;
                    }
                    else if (attr.IsTypeOf(typeof(Dapper.Contrib.Extensions.ExplicitKeyAttribute)))
                        PrimaryKey = true;
                    else if (attr.IsTypeOf(typeof(DapperORM.Attributes.KeyAttribute)))
                    {
                        PrimaryKey = true;
                        Identity.Enabled = attr.As<DapperORM.Attributes.KeyAttribute>().Identity;
                        Identity.Seed = attr.As<DapperORM.Attributes.KeyAttribute>().Seed;
                        Identity.Increment = attr.As<DapperORM.Attributes.KeyAttribute>().Increment;
                    }
                    else if (attr.IsTypeOf(typeof(DapperORM.Attributes.IdentityAttribute)))
                    {
                        Identity.Enabled = attr.As<DapperORM.Attributes.IdentityAttribute>().Identity;
                        Identity.Seed = attr.As<DapperORM.Attributes.IdentityAttribute>().Seed;
                        Identity.Increment = attr.As<DapperORM.Attributes.IdentityAttribute>().Increment;
                    }


                }
                if (ColumnType != typeof(string))
                    StringLength = null;
            }
            public string ColumnName { get; set; } = string.Empty;
            public SQLCollateTypes CollateType { get; set; } = SQLCollateTypes.Default;
            public string MaskedWith { get; set; } = string.Empty;
            public SQLColumnIdentityDefinition Identity { get; set; } = new SQLColumnIdentityDefinition();
            public bool IsNullable { get; set; } = false;
            public Type ColumnType { get; set; } = null;
            public SqlDbType? SpecifiedDbType { get; set; } = null;
            public int? StringLength { get; set; } = null;
            public bool PrimaryKey { get; set; } = false;
            public bool IsEnum { get; set; } = false;
            public SQLRelationalColumnDefinition RelationalField { get; set; } = null;
            public bool ColumnExists { get; set; } = false;
        }
        private class SQLColumnIdentityDefinition
        {
            public bool Enabled { get; set; } = false;
            public int Seed { get; set; } = 1;
            public int Increment { get; set; } = 1;
        }
        private class SQLRelationalColumnDefinition
        {
            public SQLRelationalColumnDefinition(Type typ)
            {
                TableDefinition = new SQLTableDefinition(typ);
            }
            public SQLTableDefinition TableDefinition { get; set; } = null;
            public SQLColumnDefinition RelationalKeyColumn 
            {
                get {
                    if (TableDefinition == null)
                        return null;
                    else
                        return TableDefinition.Columns.FirstOrDefault(f => f.PrimaryKey);
                } 
            }
            public string RelationalColumnName { get; set; }
            public Attributes.RelationshipAttribute RelationProperties { get; set; } = new Attributes.RelationshipAttribute();
        }
        public bool CreateOrAlterTable<T>()
        {

            SQLTableDefinition tableDefinition = new SQLTableDefinition(typeof(T));

            tableDefinition.TableExists = Connection.ExecuteScalar<bool>($@"
                SELECT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_SCHEMA = @schemaName AND  TABLE_NAME = @tableName)"
                , new
                {
                    schemaName = tableDefinition.Schema,
                    tableName = tableDefinition.TableName
                });

            StringBuilder queryBuilder = new StringBuilder();

            if (!tableDefinition.TableExists)
            {
                string createScript = $@"
                CREATE TABLE
                    [{Connection.Database}].[{tableDefinition.Schema}].[{tableDefinition.TableName}]
                (
                    {tableDefinition.Columns.Select(column => String.Format(@"[{0}] {1}{2} {3} {4} {5}", new string[]
                                {
                                    (column.RelationalField == null ? column.ColumnName : column.ColumnName + column.RelationalField.RelationalColumnName),
                                    (column.RelationalField == null ? column.SpecifiedDbType.ToString() : column.RelationalField.RelationalKeyColumn.SpecifiedDbType.ToString()),
                                    (column.RelationalField == null ? (column.StringLength.HasValue ? "(" + column.StringLength.Value.ToString() + ")" : "") : ((column.RelationalField.RelationalKeyColumn.StringLength.HasValue ? "(" + column.RelationalField.RelationalKeyColumn.StringLength.Value.ToString() + ")" : ""))),
                                    (column.RelationalField == null ? (column.MaskedWith.IsNotNullOrEmpty() ? $"MASKED WITH (FUNCTION = '{column.MaskedWith}')" : "") : (column.RelationalField.RelationalKeyColumn.MaskedWith.IsNotNullOrEmpty() ? $"MASKED WITH (FUNCTION = '{column.RelationalField.RelationalKeyColumn.MaskedWith}')" : "")),
                                    (column.RelationalField == null ? (column.Identity.Enabled ? $"IDENTITY({column.Identity.Seed},{column.Identity.Increment})" : "") : ""),
                                    (column.IsNullable || (column.RelationalField != null && (column.RelationalField.RelationProperties.DeleteRule == SQLRelationshipActions.SetNull || column.RelationalField.RelationProperties.UpdateRule == SQLRelationshipActions.SetNull)) ? "NULL" : "NOT NULL")
                                })).StringJoin("," + Environment.NewLine)}
                    {tableDefinition.Columns.Where(w => w.PrimaryKey).Take(1).Select(s => $",PRIMARY KEY ( [{s.ColumnName}] ASC)").FirstOrDefault()}
                    {tableDefinition.Columns.Where(w => w.RelationalField != null).Select(s => {
                                    return $@"
                                            ,CONSTRAINT FK_{tableDefinition.TableName}_{s.RelationalField.RelationalColumnName} 
                                             FOREIGN KEY ([{s.RelationalField.RelationalColumnName}]) 
                                             REFERENCES [{s.RelationalField.TableDefinition.Schema}].[{s.RelationalField.TableDefinition.TableName}]([{s.RelationalField.RelationalKeyColumn.ColumnName}]) 
                                             ON DELETE {s.RelationalField.RelationProperties.DeleteRule.GetSQLText()} 
                                             ON UPDATE {s.RelationalField.RelationProperties.UpdateRule.GetSQLText()}";
                                }).StringJoin(Environment.NewLine)}
                )
                ";
                queryBuilder.AppendLine(createScript);
                tableDefinition.TableExists = true;
            }
            else
            {
                List<string> oldColumnNames = Connection.Query<string>("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = @schemaName AND TABLE_NAME = @tableName", new { schemaName = tableDefinition.Schema, tableName = tableDefinition.TableName }).ToList();
                tableDefinition.Columns.ForEach(column =>
                {
                    column.ColumnExists = oldColumnNames.Any(a => a == column.ColumnName);
                    var dbColumn = column.RelationalField == null ? column : column.RelationalField.RelationalKeyColumn;
                    dbColumn.ColumnName = column.RelationalField == null ? column.ColumnName : column.ColumnName + column.RelationalField.RelationalKeyColumn.ColumnName;
                    if (column.ColumnExists)
                    {
                        dbColumn.IsNullable = column.IsNullable
                                              || (
                                                    column.RelationalField != null
                                                    && (
                                                               column.RelationalField.RelationProperties.DeleteRule == SQLRelationshipActions.SetNull
                                                            || column.RelationalField.RelationProperties.UpdateRule == SQLRelationshipActions.SetNull
                                                       )
                                                 );


                        queryBuilder.AppendLine($@"
                                ALTER TABLE [{Connection.Database}].[{tableDefinition.Schema}].[{tableDefinition.TableName}]
                                ALTER COLUMN [{dbColumn.ColumnName}]
                                {dbColumn.SpecifiedDbType.ToString()}{(dbColumn.StringLength.HasValue ? $"({dbColumn.StringLength.Value.ToString()})" : "")}
                                {(dbColumn.CollateType == SQLCollateTypes.Default ? "" : $"COLLATE {dbColumn.CollateType.ToString()}")}
                                {(dbColumn.IsNullable ? "NULL" : "NOT NULL")}
                                {(dbColumn.MaskedWith.IsNotNullOrEmpty() ? $"MASKED WITH (FUNCTION = '{dbColumn.MaskedWith}')" : "")}
                                
                                ");
                    }
                    else
                    {
                        queryBuilder.AppendLine($@"
                                        ALTER TABLE [{Connection.Database}].[{tableDefinition.Schema}].[{tableDefinition.TableName}]
                                        ADD COLUMN  [{dbColumn.ColumnName}]
                                        {dbColumn.SpecifiedDbType.ToString()}{(dbColumn.StringLength.HasValue ? $"({dbColumn.StringLength.Value.ToString()})" : "")}
                                        {(dbColumn.CollateType == SQLCollateTypes.Default ? "" : $"COLLATE {dbColumn.CollateType.ToString()}")}
                                        {(dbColumn.IsNullable ? "NULL" : "NOT NULL")}
                                        {(dbColumn.RelationalField == null ? (dbColumn.Identity.Enabled ? $"IDENTITY({dbColumn.Identity.Seed},{dbColumn.Identity.Increment})" : "") : "")}
                                        {(dbColumn.MaskedWith.IsNotNullOrEmpty() ? $"MASKED WITH (FUNCTION = '{dbColumn.MaskedWith}')" : "")}
                                        {(dbColumn.PrimaryKey ? $" CONSTRAINT {tableDefinition.TableName}_{dbColumn.ColumnName}_PK PRIMARY KEY ( [{dbColumn.ColumnName}] ASC)" : "")}
                                        {(column.RelationalField == null ? "" : $@"
                                            ,CONSTRAINT FK_{tableDefinition.TableName}_{column.RelationalField.RelationalColumnName} 
                                             FOREIGN KEY ([{column.RelationalField.RelationalColumnName}]) 
                                             REFERENCES [{column.RelationalField.TableDefinition.Schema}].[{column.RelationalField.TableDefinition.TableName}]([{column.RelationalField.RelationalKeyColumn.ColumnName}]) 
                                             ON DELETE {column.RelationalField.RelationProperties.DeleteRule.GetSQLText()} 
                                             ON UPDATE {column.RelationalField.RelationProperties.UpdateRule.GetSQLText()}
                        ")}
                ");

                    }



                });
            }

            Connection.Execute(queryBuilder.ToString());

            return true;

           
        }

        public IDictionary<string, List<Tuple<object, long, bool>>> Insert(Action<IDapperInsertRepository> config, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
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
