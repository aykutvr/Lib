using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
public static partial class Extensions
{
    public static List<T> AddIf<T>(this List<T> val, bool condition, T item)
    {
        if (condition)
            val.Add(item);
        return val;
    }
}
