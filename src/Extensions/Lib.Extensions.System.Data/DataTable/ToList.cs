using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Text;

public static partial class Extensions
{
    public static List<T> ToList<T>(this DataTable dtVal)
           where T : class, new()
    {
        if (dtVal == null)
            return null;
        List<T> lstResult = new List<T>();
        foreach (DataRow dr in dtVal.Rows)
        {
            T tempData = new T();
            foreach (DataColumn colItem in dtVal.Columns)
            {
                if (tempData.GetType().TryGetProperty(colItem.ColumnName, out PropertyInfo propInfo))
                    propInfo.SetValue(tempData, dr[colItem.ColumnName]);
            }

            lstResult.Add(tempData);
        }
        return lstResult;
    }
}
