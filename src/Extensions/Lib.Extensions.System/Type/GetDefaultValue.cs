using System;
using System.Text;

public static partial class Extensions
{
    public static object GetDefaultValue(this Type tpVal)
    {
        if (tpVal.IsValueType)
            return Activator.CreateInstance(tpVal);

        return null;
    }
}
