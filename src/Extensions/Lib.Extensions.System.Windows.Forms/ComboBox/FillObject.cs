using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
public static partial class Extensions
{
    public static void FillObject(this ComboBox @this, params string[] strArray)
           => @this.DataSource = strArray;
    public static void FillObject(this ComboBox @this, DataTable dtSource)
        => FillObject(@this, dtSource, dtSource.Columns.Count > 0 ? dtSource.Columns[0].ColumnName : "", dtSource.Columns.Count > 0 ? dtSource.Columns[0].ColumnName : "");
    public static void FillObject(this ComboBox @this, DataTable dtSource, string valueMember)
        => FillObject(@this, dtSource, valueMember, valueMember);
    public static void FillObject(this ComboBox @this, DataTable dtSource, string valueMember, string displayMember)
    {
        @this.DataSource = dtSource.DefaultView;
        @this.DisplayMember = displayMember;
        @this.ValueMember = valueMember;
    }
    public static void FillObject(this ComboBox @this, object objSource, string valueMember, string displayMember)
    {
        @this.DataSource = objSource;
        @this.DisplayMember = displayMember;
        @this.ValueMember = valueMember;
    }
    public static void FillObject<T>(this ComboBox @this, List<T> objSource, string valueMember, string displayMember)
    {
        @this.DataSource = objSource;
        @this.DisplayMember = displayMember;
        @this.ValueMember = valueMember;
    }
}
