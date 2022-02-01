﻿using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     An object extension method that converts the @this to a boolean.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>@this as a bool.</returns>
    public static bool ToBoolean(this object @this)
    {
        return Convert.ToBoolean(@this);
    }
}
