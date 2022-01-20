using Lib.Excel.Repositories.Workbook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Excel.Repositories.File
{
    public class ExcelFileRepository : IExcelFileRepository
    {
        public IExcelWorkbookRepository CreateWorkbook()
        {
            throw new NotImplementedException();
        }

        public IExcelWorkbookRepository CreateWorkbook(Action<FileConfigurator> config)
        {
            throw new NotImplementedException();
        }
    }
}
