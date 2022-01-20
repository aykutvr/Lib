﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
public static partial class Extensions
{
    /// <summary>
    ///     An IEnumerable&lt;T&gt; extension method that queries if a null or is empty.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The collection to act on.</param>
    /// <returns>true if a null or is t>, false if not.</returns>
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> @this)
    {
        return @this == null || !@this.Any();
    }
}
