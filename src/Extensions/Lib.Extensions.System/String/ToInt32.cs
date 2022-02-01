using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static partial class Extensions
{
    public static int ToInt32(this string val)
    {
        return Convert.ToInt32(string.IsNullOrEmpty(val) ? "0" : val);
    }
}


