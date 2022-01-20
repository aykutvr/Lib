using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Localization.Dto
{
    [DapperORM.Attributes.Table("LibLocalization")]
    public class LocalizationDto
    {
        [Key]
        public int Id { get; set; } = 0;
        public int LanguageId { get; set; } = 0;
        public string KeyString { get; set; } = string.Empty;
        public string ValueString { get; set; } = string.Empty;
        public string SourcePath { get; set; } = string.Empty;
    }
}
