using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static partial class Extensions
{
    public static bool ToBoolean(this string val)
           => Convert.ToBoolean(val);
}


