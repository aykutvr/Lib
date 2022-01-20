﻿using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     Converts the current date and time to Coordinated Universal Time (UTC).
    /// </summary>
    /// <param name="dateTime">The date and time to convert.</param>
    /// <returns>
    ///     The Coordinated Universal Time (UTC) that corresponds to the  parameter. The  value&#39;s  property is always
    ///     set to .
    /// </returns>
    public static DateTime ConvertTimeToUtc(this DateTime dateTime)
    {
        return TimeZoneInfo.ConvertTimeToUtc(dateTime);
    }

    /// <summary>
    ///     Converts the time in a specified time zone to Coordinated Universal Time (UTC).
    /// </summary>
    /// <param name="dateTime">The date and time to convert.</param>
    /// <param name="sourceTimeZone">The time zone of .</param>
    /// <returns>
    ///     The Coordinated Universal Time (UTC) that corresponds to the  parameter. The  object&#39;s  property is
    ///     always set to .
    /// </returns>
    public static DateTime ConvertTimeToUtc(this DateTime dateTime, TimeZoneInfo sourceTimeZone)
    {
        return TimeZoneInfo.ConvertTimeToUtc(dateTime, sourceTimeZone);
    }
}
