﻿using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     Converts the numeric Unicode character at the specified position in a specified string to a double-precision
    ///     floating point number.
    /// </summary>
    /// <param name="s">A .</param>
    /// <param name="index">The character position in .</param>
    /// <returns>
    ///     The numeric value of the character at position  in  if that character represents a number; otherwise, -1.
    /// </returns>
    public static Double GetNumericValue(this String s, Int32 index)
    {
        return Char.GetNumericValue(s, index);
    }
}
