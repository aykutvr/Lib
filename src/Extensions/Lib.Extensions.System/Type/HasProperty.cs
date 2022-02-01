using System;
using System.Linq;
using System.Text;

public static partial class Extensions
{
    public static bool HasProperty(this Type tpVal, string propName)
              => tpVal.GetProperties().Any(a => a.Name == propName);
}
