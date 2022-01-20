using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static partial class Extensions
{
    public static List<DateTime> DatesOfMonth(this DateTime @this)
    {
        return Enumerable.Range(0, DateTime.DaysInMonth(@this.Year, @this.Month)).Select(i => new DateTime(@this.Year, @this.Month, i + 1)).ToList();
    }
}
