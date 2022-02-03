using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Lib.Excel.Repositories
{
    public interface IExcelWorksheetRepository
    {
        OfficeOpenXml.ExcelWorksheet Worksheet { get; }
        void SetName(string name);
        void SetData(DataTable dataTable);
        void SetData(DataTable dataTable, bool printHeaders);
        void SetData(DataTable dataTable, OfficeOpenXml.Table.TableStyles tableStyle);
        void SetData(DataTable dataTable, bool printHeaders, OfficeOpenXml.Table.TableStyles tableStyle);
        void SetData(IEnumerable<object[]> data);
        void SetData<T>(IEnumerable<T> collection);
        void SetData<T>(IEnumerable<T> collection, bool printHeaders);
        void SetData<T>(IEnumerable<T> collection, System.Reflection.BindingFlags bindingFlags);
        void SetData<T>(IEnumerable<T> collection, bool printHeaders, System.Reflection.BindingFlags bindingFlags);
        void SetData<T>(IEnumerable<T> collection, bool printHeaders, OfficeOpenXml.LoadFunctions.Params.HeaderParsingTypes headerParsingType, System.Reflection.BindingFlags bindingFlags, string tableName, OfficeOpenXml.Table.TableStyles tableStyle, System.Reflection.MemberInfo[] members);
        void SetData<T>(IEnumerable<T> collection, Action<OfficeOpenXml.LoadFunctions.Params.LoadFromCollectionParams> config);
        ExcelRange Cells(string address);
        ExcelRange Cells(int row, int col);
        ExcelRange Cells(int fromRow, int fromCol, int toRow, int toCol);
        ExcelRangeRow Rows(int row);
        ExcelRangeRow Rows(int fromRow, int toRow);
        ExcelRangeRow Columns(int row);
        ExcelRangeRow Columns(int fromRow, int toRow);

    }

}
