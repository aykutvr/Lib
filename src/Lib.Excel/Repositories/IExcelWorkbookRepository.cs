using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Excel.Repositories
{
    public interface IExcelWorkbookRepository
    {
        OfficeOpenXml.ExcelWorkbook Workbook { get; }
        void Author(string author);
        void Category(string category);
        void Company(string company);
        void CreateDate(DateTime date);
        void Manager(string manager);
        void Title(string title);
        void Subject(string subject);
        void SetPassword(string password);
        void Worksheet(Action<IExcelWorksheetRepository> config);
        void Worksheet(string pageName, Action<IExcelWorksheetRepository> config);
        void Worksheet(int pageIndex, Action<IExcelWorksheetRepository> config);
    }
}
