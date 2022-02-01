using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    public static Int32 DaysInMonth(this Int32 year, Int32 month)
    {
        return DateTime.DaysInMonth(year, month);
    }
}
