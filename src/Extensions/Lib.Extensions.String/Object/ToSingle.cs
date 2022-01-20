﻿using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     An object extension method that converts the @this to a single.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>@this as a float.</returns>
    public static float ToSingle(this object @this)
    {
        return Convert.ToSingle(@this);
    }
}
