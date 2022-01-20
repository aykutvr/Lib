using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Logger.Dto
{
    [DapperORM.Attributes.Table("LibLog")]
    public class LogDto
    {
        [Key]
        public int Id { get; set; } = 0;
        public DateTime Date { get; set; } = DateTime.Now;
        [MaxLength(4000)]
        public string Message { get; set; } = "";
        [MaxLength(4000)]
        public string Description { get; set; } = "";

        public string LogType { get; set; } = "";
        public int UserId { get; set; } = 0;
        [MaxLength(500)]
        public string CallerFilePath { get; set; } = "";
        [MaxLength(100)]
        public string CallerMemberName { get; set; } = "";
        public int CallerLineNumber { get; set; } = -1;

        [DefaultValue("")]
        [MaxLength(100)]
        public string RemoteIpAddress { get; set; } = "";
        [DefaultValue("")]
        [MaxLength(100)]
        public string ClientHostName { get; set; } = "";
        [DefaultValue("")]
        [MaxLength(100)]
        public string RequestPath { get; set; } = "";
        [DefaultValue("")]
        [MaxLength(100)]
        public string RequestMethod { get; set; } = "";
        [DefaultValue("")]
        [MaxLength(100)]
        public string UserName { get; set; } = "";
        [DefaultValue("")]
        [MaxLength(500)]
        public string QueryString { get; set; } = "";
    }
}
