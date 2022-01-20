using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Excel.Models
{
    public class ExcelFileInfo
    {
        public string Author { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
