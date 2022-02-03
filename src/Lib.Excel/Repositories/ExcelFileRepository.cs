using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Excel.Repositories
{
    public class ExcelFileRepository : IExcelFileRepository
    {

        public ExcelPackage Package { get; }

        public ExcelFileRepository()
        {
            Package = new OfficeOpenXml.ExcelPackage();
        }
        public IExcelFileRepository Workbook()
        {
            return Workbook(action => { });
        }
        public IExcelFileRepository Workbook(Action<IExcelWorkbookRepository> config)
        {
            IExcelWorkbookRepository workbook = new Workbook.ExcelWorkbookRepository(Package.Workbook);
            config.Invoke(workbook);
            return this;
        }
        public IExcelFileRepository SetCompression(CompressionLevel level)
        {
            Package.Compression = (OfficeOpenXml.CompressionLevel)Enum.Parse(typeof(OfficeOpenXml.CompressionLevel),level.ToString());
            return this;
        }

        #region Save Methods

        public void Save(string filePath)
            => Package.SaveAs(filePath);
        public void Save(string filePath, string password)
            => Package.SaveAs(filePath, password);
        public void Save(FileInfo fileInfo)
            => Package.SaveAs(fileInfo);
        public void Save(FileInfo fileInfo, string password)
            => Package.SaveAs(fileInfo, password);
        public void Save(Stream outputStream)
            => Package.SaveAs(outputStream);
        public void Save(Stream outputStream, string password)
            => Package.SaveAs(outputStream, password);
        #endregion Save Methods
        #region Load Methods

        public IExcelFileRepository Load(Stream stream)
        {
            Package.Load(stream);
            return this;
        }
        public IExcelFileRepository Load(Stream stream, string password)
        {
            Package.Load(stream, password);
            return this;
        }
        #endregion Load Methods
    }
}
