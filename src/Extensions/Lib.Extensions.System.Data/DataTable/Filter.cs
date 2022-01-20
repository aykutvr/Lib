using System;
using System.ComponentModel;
using System.Data;
using System.Text;

public static partial class Extensions
{
    public static DataTable Filter(this DataTable dTable, string filterExpression, string sort = "")
    {
        DataRow[] drFiltered = dTable.Select(filterExpression, sort);
        if (drFiltered == null || drFiltered.Length == 0)
            return null;

        DataTable dtTemp = dTable.Copy();
        dTable.Rows.Clear();
        foreach (DataRow item in drFiltered)
        {
            dtTemp.Rows.Add(item);
        }
        return dtTemp;
    }
}
