﻿using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     Returns a value indicating whether the specified number evaluates to negative infinity.
    /// </summary>
    /// <param name="d">A double-precision floating-point number.</param>
    /// <returns>true if  evaluates to ; otherwise, false.</returns>
    public static Boolean IsNegativeInfinity(this Double d)
    {
        return Double.IsNegativeInfinity(d);
    }
}
