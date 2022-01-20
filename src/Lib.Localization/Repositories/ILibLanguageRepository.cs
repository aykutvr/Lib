using Lib.Localization.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Localization.Repositories
{
    public interface ILibLanguageRepository
    {
        LanguageDto Get(int languageId,[CallerFilePath]string callerFilePath = "",[CallerMemberName]string callerMemberName = "", [CallerLineNumber]int callerLineNumber = -1);
        LanguageDto Get(string name, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        LanguageDto GetDefault([CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        List<LanguageDto> List([CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        List<LanguageDto> List(bool isActive, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        LanguageDto Insert(LanguageDto data, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        LanguageDto Update(LanguageDto data, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
        bool Delete(int languageId, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1);
    }
}
