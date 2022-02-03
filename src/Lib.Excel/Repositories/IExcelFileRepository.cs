using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Excel.Repositories
{
    public interface IExcelFileRepository
    {
        OfficeOpenXml.ExcelPackage Package { get; }
        IExcelFileRepository Workbook();
        IExcelFileRepository Workbook(Action<IExcelWorkbookRepository> config);
        IExcelFileRepository SetCompression(CompressionLevel level);
        void Save(string filePath);
        void Save(string filePath, string password);
        void Save(FileInfo fileInfo);
        void Save(FileInfo fileInfo, string password);
        void Save(Stream outputStream);
        void Save(Stream outputStream,string password);
        IExcelFileRepository Load(Stream stream);
        IExcelFileRepository Load(Stream stream,string password);
    }
}
