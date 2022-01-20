﻿using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     A T extension method that null if equals.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <param name="value">The value.</param>
    /// <returns>A T.</returns>
    public static T NullIfEquals<T>(this T @this, T value) where T : class
    {
        if (@this.Equals(value))
        {
            return null;
        }
        return @this;
    }
}
