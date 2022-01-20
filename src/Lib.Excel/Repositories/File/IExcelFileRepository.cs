using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Excel.Repositories.File
{
    public interface IExcelFileRepository
    {
        Workbook.IExcelWorkbookRepository CreateWorkbook();
        Workbook.IExcelWorkbookRepository CreateWorkbook(Action<FileConfigurator> config);
    }
}
