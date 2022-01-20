﻿using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     Returns the specified 32-bit signed integer value as an array of bytes.
    /// </summary>
    /// <param name="value">The number to convert.</param>
    /// <returns>An array of bytes with length 4.</returns>
    public static Byte[] GetBytes(this Int64 value)
    {
        return BitConverter.GetBytes(value);
    }
}
