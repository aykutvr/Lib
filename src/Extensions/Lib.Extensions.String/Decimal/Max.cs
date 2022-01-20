﻿using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     Returns the larger of two decimal numbers.
    /// </summary>
    /// <param name="val1">The first of two decimal numbers to compare.</param>
    /// <param name="val2">The second of two decimal numbers to compare.</param>
    /// <returns>Parameter  or , whichever is larger.</returns>
    public static Decimal Max(this Decimal val1, Decimal val2)
    {
        return Math.Max(val1, val2);
    }
}
