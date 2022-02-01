﻿using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     An Int32 extension method that hours the given this.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>A TimeSpan.</returns>
    public static TimeSpan Hours(this Int32 @this)
    {
        return TimeSpan.FromHours(@this);
    }
}
