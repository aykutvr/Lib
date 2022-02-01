using System;
using System.Reflection;
using System.Text;

public static partial class Extensions
{
    public static bool TryGetProperty(this Type tpVal, string propName, out PropertyInfo propertyInfo)
    {
        propertyInfo = null;
        if (tpVal.HasProperty(propName))
            propertyInfo = tpVal.GetProperty(propName);

        return tpVal.HasProperty(propName);
    }
}
