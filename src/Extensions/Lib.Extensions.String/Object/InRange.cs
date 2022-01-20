﻿using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     A T extension method that check if the value is between inclusively the minValue and maxValue.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <param name="minValue">The minimum value.</param>
    /// <param name="maxValue">The maximum value.</param>
    /// <returns>true if the value is between inclusively the minValue and maxValue, otherwise false.</returns>
    public static bool InRange<T>(this T @this, T minValue, T maxValue) where T : IComparable<T>
    {
        return @this.CompareTo(minValue) >= 0 && @this.CompareTo(maxValue) <= 0;
    }
}
