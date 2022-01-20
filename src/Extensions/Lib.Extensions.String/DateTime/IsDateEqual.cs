﻿using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     A DateTime extension method that query if 'date' is date equal.
    /// </summary>
    /// <param name="date">The date to act on.</param>
    /// <param name="dateToCompare">Date/Time of the date to compare.</param>
    /// <returns>true if date equal, false if not.</returns>
    public static bool IsDateEqual(this DateTime date, DateTime dateToCompare)
    {
        return (date.Date == dateToCompare.Date);
    }
}
