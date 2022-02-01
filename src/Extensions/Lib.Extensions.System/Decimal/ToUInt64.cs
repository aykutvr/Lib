﻿using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     Converts the value of the specified  to the equivalent 64-bit unsigned integer.
    /// </summary>
    /// <param name="d">The decimal number to convert.</param>
    /// <returns>A 64-bit unsigned integer equivalent to the value of .</returns>
    public static UInt64 ToUInt64(this Decimal d)
    {
        return Decimal.ToUInt64(d);
    }
}
