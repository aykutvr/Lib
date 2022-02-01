using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     Returns a value indicating whether the specified date and time is within the specified daylight saving time
    ///     period.
    /// </summary>
    /// <param name="time">A date and time.</param>
    /// <param name="daylightTimes">A daylight saving time period.</param>
    /// <returns>true if  is in ; otherwise, false.</returns>
    public static Boolean IsDaylightSavingTime(this DateTime time, DaylightTime daylightTimes)
    {
        return TimeZone.IsDaylightSavingTime(time, daylightTimes);
    }
}
