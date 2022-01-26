using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Localization
{
    public class SharedSettings
    {
        public static string ConnectionString { get; set; } = string.Empty;
        public static Dto.LanguageDto DefaultLanguage { get; set; } = new Dto.LanguageDto();
    }
}
