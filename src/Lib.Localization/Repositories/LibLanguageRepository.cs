using Lib.Localization.Dto;
using Lib.Localization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Localization.Repositories
{
    public class LibLanguageRepository : ILibLanguageRepository
    {
        private DapperORM.Repositories.IDapperConnectRepository Dapper { get; }
        public LibLanguageRepository(DapperORM.Repositories.IDapperConnectRepository dapper)
        {
            Dapper = dapper;
        }

        public Language Get(int languageId, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            => Dapper
                .Connect(SharedSettings.ConnectionString)
                .Get<Language>(
                    "SELECT TOP 1 * FROM LibLanguage WHERE Id = @id"
                    , new { id = languageId }
                    , System.Data.CommandType.Text
                    , callerFilePath
                    , callerMemberName
                    , callerLineNumber
                );

        public Language Get(string name, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            => Dapper
                .Connect(SharedSettings.ConnectionString)
                .Get<Language>(
                    "SELECT TOP 1 * FROM LibLanguage WHERE Name = @name"
                    , new { name = name }
                    , System.Data.CommandType.Text
                    , callerFilePath
                    , callerMemberName
                    , callerLineNumber
                );

        public Language GetDefault([CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            => Dapper
                .Connect(SharedSettings.ConnectionString)
                .Get<Language>(
                    "SELECT TOP 1 * FROM LibLanguage WHERE IsDefault = 1"
                    ,null
                    , System.Data.CommandType.Text
                    , callerFilePath
                    , callerMemberName
                    , callerLineNumber
                );

        public List<Language> List([CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            => Dapper
                .Connect(SharedSettings.ConnectionString)
                .List<Language>(
                    "SELECT * FROM LibLanguage"
                    , null
                    , System.Data.CommandType.Text
                    , callerFilePath
                    , callerMemberName
                    , callerLineNumber
                );

        public List<Language> List(bool isActive, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            => Dapper
                .Connect(SharedSettings.ConnectionString)
                .List<Language>(
                    "SELECT * FROM LibLanguage WHERE IsActive = 1"
                    , null
                    , System.Data.CommandType.Text
                    , callerFilePath
                    , callerMemberName
                    , callerLineNumber
                );

        public Language Update(Language data, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            Dapper
                .Connect(SharedSettings.ConnectionString)
                .Update(
                    data
                    , callerFilePath
                    , callerMemberName
                    , callerLineNumber
                );
            return data;
        }
        public bool Delete(int languageId, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            return Dapper
                    .Connect(SharedSettings.ConnectionString)
                    .Delete<LanguageDto>(
                        languageId
                        , callerFilePath
                        , callerMemberName
                        , callerLineNumber
                    );
        }

        public LanguageDto Insert(LanguageDto data, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            return Dapper
               .Connect(SharedSettings.ConnectionString)
               .Insert<LanguageDto>(data,callerFilePath,callerMemberName,callerLineNumber);
        }
    }
}
