using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    public static Int32 DaysInMonth(this Int16 year, Int16 month)
    {
        return DateTime.DaysInMonth(year, month);
    }
}
