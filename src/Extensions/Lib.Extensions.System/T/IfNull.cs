using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    public static T IfNull<T>(this T @this,T value)
    {
        if (@this == null)
            return value;
        else
            return @this;
    }
}
