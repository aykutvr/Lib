using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static partial class Extensions
{
    public static void ToExcel(this DataTable @this, string fileName)
    {
        new Lib
            .Excel
            .Repositories
            .ExcelFileRepository()
            .Workbook(book =>
            {
                book.Title(@this.TableName);
                book.Worksheet(sheet =>
                {
                    sheet.SetData(@this);
                });
            })
            .Save(fileName);
    }
    public static void ToExcel<T>(this IEnumerable<T> @this,string fileName)
    {
        new Lib
            .Excel
            .Repositories
            .ExcelFileRepository()
            .Workbook(book =>
            {
                book.Title(@this.GetType().Name);
                book.Worksheet(sheet =>
                {
                    sheet.SetData(@this);
                });
            })
            .Save(fileName);
    }
}
