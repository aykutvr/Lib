﻿using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     Converts the value of the specified  to the equivalent 32-bit signed integer.
    /// </summary>
    /// <param name="d">The decimal number to convert.</param>
    /// <returns>A 32-bit signed integer equivalent to the value of .</returns>
    public static Int32 ToInt32(this Decimal d)
    {
        return Decimal.ToInt32(d);
    }
}
