using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    public static bool IsTypeOf(this object @this, Type type)
    {
        return @this.GetType() == type;
    }
}
