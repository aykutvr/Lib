using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

public static partial class Extensions
{
    public static void FillObject(this System.Windows.Forms.ComboBox @this,string connectionString,string query,object param = null,[CallerFilePath]string callerFilePath = "",[CallerMemberName]string callerMemberName = "",[CallerLineNumber]int callerLineNumber = -1)
    {
        @this.FillObject(new Lib
                             .DapperORM
                             .Repositories
                             .DapperConnectRepository()
                             .Connect(connectionString, callerFilePath, callerMemberName, callerLineNumber)
                             .DataTable(query,param,System.Data.CommandType.Text,callerFilePath,callerMemberName,callerLineNumber));
    }
    public static void FillObject(this System.Windows.Forms.ComboBox @this, string connectionString, string query,string valueMember,string displayMember, object param = null, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
    {
        @this.FillObject(new Lib
                             .DapperORM
                             .Repositories
                             .DapperConnectRepository()
                             .Connect(connectionString, callerFilePath, callerMemberName, callerLineNumber)
                             .DataTable(query, param, System.Data.CommandType.Text, callerFilePath, callerMemberName, callerLineNumber),valueMember,displayMember);
    }
}
