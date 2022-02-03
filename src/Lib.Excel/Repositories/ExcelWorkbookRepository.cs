using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Excel.Repositories
{
    public class ExcelWorkbookRepository : IExcelWorkbookRepository
    {
        public OfficeOpenXml.ExcelWorkbook Workbook { get; }
        public ExcelWorkbookRepository(OfficeOpenXml.ExcelWorkbook workbook)
        {
            Workbook = workbook;
        }

        public void Author(string author)
            => Workbook.Properties.Author = author;

        public void Category(string category)
            => Workbook.Properties.Category = category;

        public void Company(string company)
            => Workbook.Properties.Company = company;

        public void CreateDate(DateTime date)
            => Workbook.Properties.Created = date;

        public void Manager(string manager)
            => Workbook.Properties.Manager = manager;

        public void Title(string title)
            => Workbook.Properties.Title = title;

        public void Subject(string subject)
            => Workbook.Properties.Subject = subject;

        public void SetPassword(string password)
            => Workbook.Protection.SetPassword(password);

        public void Worksheet(Action<IExcelWorksheetRepository> config)
            => Worksheet("Page 1", config);
        public void Worksheet(string pageName, Action<IExcelWorksheetRepository> config)
        {
            if (Workbook.Worksheets.Any(a => a.Name == pageName))
                Worksheet(Workbook.Worksheets[pageName], config);
            else
                Worksheet(Workbook.Worksheets.Add(pageName), config);
        }
        public void Worksheet(int pageIndex, Action<IExcelWorksheetRepository> config)
            => Worksheet(Workbook.Worksheets[pageIndex], config);
        private void Worksheet(OfficeOpenXml.ExcelWorksheet worksheet, Action<IExcelWorksheetRepository> config)
        {
            config.Invoke(new ExcelWorksheetRepository(worksheet));
        }

    }
}
