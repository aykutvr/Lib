using Lib.Localization.Builders;
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
            => List(config =>
            {
                config.SetId(id);
            }).FirstOrDefault();

        public LocalizationDto Get(
                                        string key
                                        , string langName
                                        , [CallerFilePath] string callerFilePath = ""
                                        , [CallerMemberName] string callerMemberName = ""
                                        , [CallerLineNumber] int callerLineNumber = -1
                                       )
            => List(config =>
            {
                config.SetKey(key);
                config.SetLanguage(langName);
            }).FirstOrDefault();

        public LocalizationDto Insert(LocalizationDto localization, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            return Dapper
               .Connect(SharedSettings.ConnectionString)
               .Insert<LocalizationDto>(localization, callerFilePath, callerMemberName, callerLineNumber);
        }



        public List<LocalizationDto> List(string lang = "", [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
            => List(config =>
                {
                    config.SetLanguage(lang);
                });

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

        public void Dispose()
        {

        }

        public List<LocalizationDto> List(Action<LocalizationListFilterBuilder> config, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            LocalizationListFilterBuilder builder = new LocalizationListFilterBuilder();
            config.Invoke(builder);
            return Dapper
                .Connect(SharedSettings.ConnectionString)
                .List<LocalizationDto,LanguageDto,LocalizationDto>(queryCfg =>
                    {
                        string query = "SELECT LCL.*, '' SPLIT, LANG.* FROM LibLocalization LCL INNER JOIN LibLanguage LANG ON LANG.Id = LCL.LanguageId WHERE 1=1 ";
                        if (builder._filter.Id.Any())
                        {
                            query += " AND LCL.Id IN @lclId";
                            queryCfg.AddParameter(new { lclId = builder._filter.Id });
                        }

                        if (builder._filter.Key.Any())
                        {
                            query += " AND LCL.KeyString IN @lclKey";
                            queryCfg.AddParameter(new { lclKey = builder._filter.Key });
                        }

                        if (builder._filter.Lang.Any())
                        {
                            query += " AND LANG.Name IN @lclLang";
                            queryCfg.AddParameter(new { lclLang = builder._filter.Lang });
                        }

                        queryCfg.SetQuery(query);
                    }
                    ,(LOCALIZATION,LANGUAGE) =>
                    {
                        if (LANGUAGE != null)
                            LOCALIZATION.Language = LANGUAGE;

                        return LOCALIZATION;
                    }
                    ,"SPLIT"
                    , callerFilePath
                    , callerMemberName
                    , callerLineNumber
                );

        }
    }
}
