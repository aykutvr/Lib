using Lib.Localization.Dto;
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

        public LanguageDto Get(int languageId, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            => Dapper
                .Connect(SharedSettings.ConnectionString)
                .Get<LanguageDto>(
                    "SELECT TOP 1 * FROM LibLanguage WHERE Id = @id"
                    , new { id = languageId }
                    , System.Data.CommandType.Text
                    , callerFilePath
                    , callerMemberName
                    , callerLineNumber
                );

        public LanguageDto Get(string name, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            => Dapper
                .Connect(SharedSettings.ConnectionString)
                .Get<LanguageDto>(
                    "SELECT TOP 1 * FROM LibLanguage WHERE Name = @name"
                    , new { name = name }
                    , System.Data.CommandType.Text
                    , callerFilePath
                    , callerMemberName
                    , callerLineNumber
                );

        public LanguageDto GetDefault([CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            => Dapper
                .Connect(SharedSettings.ConnectionString)
                .Get<LanguageDto>(
                    "SELECT TOP 1 * FROM LibLanguage WHERE IsDefault = 1"
                    ,null
                    , System.Data.CommandType.Text
                    , callerFilePath
                    , callerMemberName
                    , callerLineNumber
                );

        public List<LanguageDto> List([CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            => Dapper
                .Connect(SharedSettings.ConnectionString)
                .List<LanguageDto>(
                    "SELECT * FROM LibLanguage"
                    , null
                    , System.Data.CommandType.Text
                    , callerFilePath
                    , callerMemberName
                    , callerLineNumber
                );

        public List<LanguageDto> List(bool isActive, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            => Dapper
                .Connect(SharedSettings.ConnectionString)
                .List<LanguageDto>(
                    "SELECT * FROM LibLanguage WHERE IsActive = 1"
                    , null
                    , System.Data.CommandType.Text
                    , callerFilePath
                    , callerMemberName
                    , callerLineNumber
                );

        public LanguageDto Update(LanguageDto data, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
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
