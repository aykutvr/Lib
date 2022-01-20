﻿using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     Returns the larger of two 32-bit signed integers.
    /// </summary>
    /// <param name="val1">The first of two 32-bit signed integers to compare.</param>
    /// <param name="val2">The second of two 32-bit signed integers to compare.</param>
    /// <returns>Parameter  or , whichever is larger.</returns>
    public static Int32 Max(this Int16 val1, Int16 val2)
    {
        return Math.Max(val1, val2);
    }
}
