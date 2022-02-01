﻿using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     Multiplies two specified  values.
    /// </summary>
    /// <param name="d1">The multiplicand.</param>
    /// <param name="d2">The multiplier.</param>
    /// <returns>The result of multiplying  and .</returns>
    public static Decimal Multiply(this Decimal d1, Decimal d2)
    {
        return Decimal.Multiply(d1, d2);
    }
}
