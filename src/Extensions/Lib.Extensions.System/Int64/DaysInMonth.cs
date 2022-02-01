using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    public static Int64 DaysInMonth(this Int64 year, Int64 month)
    {
        return DateTime.DaysInMonth(year.ToInt32(), month.ToInt32());
    }
}
