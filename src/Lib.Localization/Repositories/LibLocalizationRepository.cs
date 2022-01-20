using Lib.Localization.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Localization.Repositories
{
    public class LibLocalizationRepository : ILibLocalizationRepository
    {
        private DapperORM.Repositories.IDapperConnectRepository Dapper { get; }
        public LibLocalizationRepository(DapperORM.Repositories.IDapperConnectRepository dapper)
        {
            Dapper = dapper;
        }
        public bool Delete(int id, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            return Dapper
                     .Connect(SharedSettings.ConnectionString)
                     .Delete<LocalizationDto>(
                         id
                         , callerFilePath
                         , callerMemberName
                         , callerLineNumber
                     );
        }

        public LocalizationDto Get(int id, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            => Dapper
                .Connect(SharedSettings.ConnectionString)
                .Get<LocalizationDto>(
                    "SELECT TOP 1 * FROM LibLocalization WHERE Id = @id"
                    , new { id = id }
                    , System.Data.CommandType.Text
                    , callerFilePath
                    , callerMemberName
                    , callerLineNumber
                );

        public LocalizationDto Get(
                                        string key
                                        , string langName
                                        , [CallerFilePath] string callerFilePath = ""
                                        , [CallerMemberName] string callerMemberName = ""
                                        , [CallerLineNumber] int callerLineNumber = -1
                                       )
            => Dapper
                .Connect(SharedSettings.ConnectionString)
                .Get<LocalizationDto>(
                    "SELECT TOP 1 * FROM LibLocalization LCL INNER JOIN LibLanguage LANG ON LANG.Id = LCL.LanguageId WHERE LCL.KeyString = @keyString AND LANG.Name = @langName"
                    , new { keyString = key, langName = langName}
                    , System.Data.CommandType.Text
                    , callerFilePath
                    , callerMemberName
                    , callerLineNumber
                );

        public LocalizationDto Insert(LocalizationDto localization, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            return Dapper
               .Connect(SharedSettings.ConnectionString)
               .Insert<LocalizationDto>(localization, callerFilePath, callerMemberName, callerLineNumber);
        }

        

        public List<LocalizationDto> List(string lang = "", [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        => Dapper
                .Connect(SharedSettings.ConnectionString)
                .List<LocalizationDto>(
                    "SELECT FROM LibLocalization LCL INNER JOIN LibLanguage LANG ON LANG.Id = LCL.LanguageId WHERE LANG.Name = @langName OR @langName = ''"
                    , new { langName = lang }
                    , System.Data.CommandType.Text
                    , callerFilePath
                    , callerMemberName
                    , callerLineNumber
                );

        public LocalizationDto Update(LocalizationDto localization, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            Dapper
               .Connect(SharedSettings.ConnectionString)
               .Update(
                   localization
                   , callerFilePath
                   , callerMemberName
                   , callerLineNumber
               );
            return localization;
        }
    }
}
