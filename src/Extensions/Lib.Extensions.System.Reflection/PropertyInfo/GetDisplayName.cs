using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

#if !NETSTANDARD
using System.ComponentModel.DataAnnotations;

public static partial class Extensions {
    public static string GetDisplayName(this PropertyInfo item)
    {
        if (item.GetCustomAttribute<DisplayNameAttribute>(true) != null)
            return item.GetCustomAttribute<DisplayNameAttribute>(true).DisplayName;

        if (item.GetCustomAttribute<DisplayAttribute>(true) != null)
            return item.GetCustomAttribute<DisplayAttribute>(true).GetName();

        return $"[{item.Name}]";
    }
}
#endif