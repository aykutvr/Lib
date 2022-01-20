using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
public static partial class Extensions
{
    public static void FillObject(this ListBox listBox, params string[] strArray)
            => listBox.DataSource = strArray;
    public static void FillObject(this ListBox listBox, DataTable dtSource)
      => FillObject(listBox, dtSource, dtSource.Columns.Count > 0 ? dtSource.Columns[0].ColumnName : "", dtSource.Columns.Count > 0 ? dtSource.Columns[0].ColumnName : "");
    public static void FillObject(this ListBox listBox, DataTable dtSource, string valueMember)
        => FillObject(listBox, dtSource, valueMember, valueMember);
    public static void FillObject(this ListBox listBox, DataTable dtSource, string valueMember, string displayMember)
    {
        listBox.DataSource = dtSource.DefaultView;
        listBox.DisplayMember = displayMember;
        listBox.ValueMember = valueMember;
    }
    public static void FillObject(this ListBox listBox, object objSource, string valueMember, string displayMember)
    {
        listBox.DataSource = objSource;
        listBox.DisplayMember = displayMember;
        listBox.ValueMember = valueMember;
    }
}
