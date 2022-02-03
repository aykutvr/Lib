using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;

namespace Lib.Excel.Repositories
{
    public class ExcelWorksheetRepository : IExcelWorksheetRepository
    {
        public ExcelWorksheet Worksheet { get; }
        public ExcelWorksheetRepository(ExcelWorksheet worksheet)
        {
            Worksheet = worksheet;
        }
        public void SetName(string name)
            => Worksheet.Name = name;

        #region Load From DataTable
        public void SetData(DataTable dataTable)
            => SetData(dataTable,config=> { config.PrintHeaders = true; config.TableStyle = OfficeOpenXml.Table.TableStyles.Light1; });
        public void SetData(DataTable dataTable,bool printHeaders)
            => SetData(dataTable,config=> { config.PrintHeaders = printHeaders; config.TableStyle = OfficeOpenXml.Table.TableStyles.Light1; });
        public void SetData(DataTable dataTable, OfficeOpenXml.Table.TableStyles tableStyle)
            => SetData(dataTable, config => { config.PrintHeaders = true; config.TableStyle = tableStyle; });
        public void SetData(DataTable dataTable,bool printHeaders, OfficeOpenXml.Table.TableStyles tableStyle)
            => SetData(dataTable, config => { config.PrintHeaders = printHeaders; config.TableStyle = tableStyle; });
        private void SetData(DataTable dataTable,Action<OfficeOpenXml.LoadFunctions.Params.LoadFromDataTableParams> config)
            => Worksheet.Cells["A1"].LoadFromDataTable(dataTable,config);
        #endregion Load From DataTable

        #region Load From Array
        public void SetData(IEnumerable<object[]> data)
            => Worksheet.Cells["A1"].LoadFromArrays(data);
        #endregion Load From Array

        #region Load From Collection
        public void SetData<T>(IEnumerable<T> collection)
            => SetData<T>(collection, config =>
            {
                config.BindingFlags = System.Reflection.BindingFlags.Default;
                config.HeaderParsingType = OfficeOpenXml.LoadFunctions.Params.HeaderParsingTypes.Preserve;
                config.PrintHeaders = true;
                config.TableName = collection.GetType().Name;
                config.TableStyle = OfficeOpenXml.Table.TableStyles.Light1;
            });
        public void SetData<T>(IEnumerable<T> collection, bool printHeaders)
           => SetData<T>(collection, config =>
           {
               config.BindingFlags = System.Reflection.BindingFlags.Default;
               config.HeaderParsingType = OfficeOpenXml.LoadFunctions.Params.HeaderParsingTypes.Preserve;
               config.PrintHeaders = printHeaders;
               config.TableName = collection.GetType().Name;
               config.TableStyle = OfficeOpenXml.Table.TableStyles.Light1;
           });
        public void SetData<T>(IEnumerable<T> collection, System.Reflection.BindingFlags bindingFlags)
            => SetData<T>(collection, config =>
            {
                config.BindingFlags = bindingFlags;
                config.HeaderParsingType = OfficeOpenXml.LoadFunctions.Params.HeaderParsingTypes.Preserve;
                config.PrintHeaders = true;
                config.TableName = collection.GetType().Name;
                config.TableStyle = OfficeOpenXml.Table.TableStyles.Light1;
            });
        public void SetData<T>(IEnumerable<T> collection,bool printHeaders, System.Reflection.BindingFlags bindingFlags)
            => SetData<T>(collection, config =>
            {
                config.BindingFlags = bindingFlags;
                config.HeaderParsingType = OfficeOpenXml.LoadFunctions.Params.HeaderParsingTypes.Preserve;
                config.PrintHeaders = printHeaders;
                config.TableName = collection.GetType().Name;
                config.TableStyle = OfficeOpenXml.Table.TableStyles.Light1;
            });
        public void SetData<T>(IEnumerable<T> collection, bool printHeaders, OfficeOpenXml.LoadFunctions.Params.HeaderParsingTypes headerParsingType, System.Reflection.BindingFlags bindingFlags,string tableName, OfficeOpenXml.Table.TableStyles tableStyle,System.Reflection.MemberInfo[] members)
            => SetData<T>(collection, config =>
            {
                config.BindingFlags = bindingFlags;
                config.HeaderParsingType = headerParsingType;
                config.PrintHeaders = printHeaders;
                config.TableName = tableName;
                config.TableStyle = tableStyle;
                config.Members = members;
            });
        public void SetData<T>(IEnumerable<T> collection, Action<OfficeOpenXml.LoadFunctions.Params.LoadFromCollectionParams> config)
           => Worksheet.Cells["A1"].LoadFromCollection<T>(collection, config);
        #endregion Load From Collection

        #region Cells
        public ExcelRange Cells(string address)
            => Worksheet.Cells[address];
        public ExcelRange Cells(int row, int col)
            => Worksheet.Cells[row, col];
        public ExcelRange Cells(int fromRow, int fromCol, int toRow, int toCol)
            => Worksheet.Cells[fromRow, fromCol, toRow, toCol];
        #endregion Cells

        #region Rows
        public ExcelRangeRow Rows(int row)
            => Worksheet.Rows[row];
        public ExcelRangeRow Rows(int fromRow, int toRow)
            => Worksheet.Rows[fromRow,toRow];
        #endregion Rows

        #region Columns
        public ExcelRangeRow Columns(int row)
            => Worksheet.Rows[row];
        public ExcelRangeRow Columns(int fromRow, int toRow)
            => Worksheet.Rows[fromRow, toRow];
        #endregion Columns
    }

}
