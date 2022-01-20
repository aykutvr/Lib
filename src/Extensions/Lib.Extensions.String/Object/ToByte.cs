﻿using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     An object extension method that converts the @this to a byte.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>@this as a byte.</returns>
    public static byte ToByte(this object @this)
    {
        return Convert.ToByte(@this);
    }
}
