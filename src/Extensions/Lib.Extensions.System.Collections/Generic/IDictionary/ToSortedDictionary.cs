﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
public static partial class Extensions
{
    /// <summary>
    ///     An IDictionary&lt;TKey,TValue&gt; extension method that converts the @this to a sorted dictionary.
    /// </summary>
    /// <typeparam name="TKey">Type of the key.</typeparam>
    /// <typeparam name="TValue">Type of the value.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <returns>@this as a SortedDictionary&lt;TKey,TValue&gt;</returns>
    public static SortedDictionary<TKey, TValue> ToSortedDictionary<TKey, TValue>(this IDictionary<TKey, TValue> @this)
    {
        return new SortedDictionary<TKey, TValue>(@this);
    }

    /// <summary>
    ///     An IDictionary&lt;TKey,TValue&gt; extension method that converts the @this to a sorted dictionary.
    /// </summary>
    /// <typeparam name="TKey">Type of the key.</typeparam>
    /// <typeparam name="TValue">Type of the value.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <param name="comparer">The comparer.</param>
    /// <returns>@this as a SortedDictionary&lt;TKey,TValue&gt;</returns>
    public static SortedDictionary<TKey, TValue> ToSortedDictionary<TKey, TValue>(this IDictionary<TKey, TValue> @this, IComparer<TKey> comparer)
    {
        return new SortedDictionary<TKey, TValue>(@this, comparer);
    }
}
