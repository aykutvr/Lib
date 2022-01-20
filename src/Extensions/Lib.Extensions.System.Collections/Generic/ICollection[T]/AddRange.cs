﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
public static partial class Extensions
{
    /// <summary>
    ///     An ICollection&lt;T&gt; extension method that adds a range to 'values'.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <param name="values">A variable-length parameters list containing values.</param>
    public static void AddRange<T>(this ICollection<T> @this, params T[] values)
    {
        foreach (T value in values)
        {
            @this.Add(value);
        }
    }
}
