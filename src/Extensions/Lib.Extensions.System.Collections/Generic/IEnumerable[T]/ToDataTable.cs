using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.ComponentModel.DataAnnotations;

public static partial class Extensions
{
    public static DataTable ToDataTable<T>(this IEnumerable<T> val)
    {
        using (DataTable dtResult = new DataTable())
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                string strCaption = prop.Name;
                bool isNullable = false;
                bool isKeyField = false;
                object objDefaultValue = DBNull.Value;
                string strExpressionString = "";
                bool isReadOnly = false;
                bool isBrowsable = true;

                if (prop.CustomAttributes.Any(a => a.GetType() == typeof(DisplayAttribute)))
                    strCaption = ((DisplayAttribute)prop.GetCustomAttributes(true).First(f => f.GetType() == typeof(DisplayAttribute))).GetName();
                else if (prop.CustomAttributes.Any(a => a.GetType() == typeof(DisplayNameAttribute)))
                    strCaption = ((DisplayNameAttribute)prop.GetCustomAttributes(true).First(f => f.GetType() == typeof(DisplayNameAttribute))).DisplayName;

                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    isNullable = true;

                if (prop.CustomAttributes.Any(a => a.GetType() == typeof(KeyAttribute)))
                    isKeyField = true;

                if (prop.CustomAttributes.Any(a => a.GetType() == typeof(DefaultValueAttribute)))
                    objDefaultValue = ((DefaultValueAttribute)prop.GetCustomAttributes(true).First(f => f.GetType() == typeof(DefaultValueAttribute))).Value;

                if (prop.CustomAttributes.Any(a => a.GetType() == typeof(RegularExpressionAttribute)))
                    strExpressionString = ((RegularExpressionAttribute)prop.GetCustomAttributes(true).First(f => f.GetType() == typeof(RegularExpressionAttribute))).Pattern;

                if (prop.CustomAttributes.Any(a => a.GetType() == typeof(ReadOnlyAttribute)))
                    isReadOnly = ((ReadOnlyAttribute)prop.GetCustomAttributes(true).First(f => f.GetType() == typeof(ReadOnlyAttribute))).IsReadOnly;

                if (prop.CustomAttributes.Any(a => a.GetType() == typeof(BrowsableAttribute)))
                    isReadOnly = ((BrowsableAttribute)prop.GetCustomAttributes(true).First(f => f.GetType() == typeof(BrowsableAttribute))).Browsable;

                DataColumn colResult = new DataColumn()
                {
                    AllowDBNull = isNullable,
                    AutoIncrement = isKeyField,
                    Caption = strCaption,
                    ColumnName = prop.Name,
                    DataType = prop.PropertyType,
                    DefaultValue = objDefaultValue,
                    Expression = strExpressionString,
                    ReadOnly = isReadOnly,
                    ColumnMapping = isBrowsable ? MappingType.Element : MappingType.Hidden
                };
                dtResult.Columns.Add(colResult);
            }
            foreach (var lstItem in val)
            {
                DataRow drItem = dtResult.NewRow();
                foreach (var item in typeof(T).GetProperties())
                {
                    drItem[item.Name] = item.GetValue(lstItem);
                }
                dtResult.Rows.Add(drItem);
            }
            return dtResult;
        }
    }
}
