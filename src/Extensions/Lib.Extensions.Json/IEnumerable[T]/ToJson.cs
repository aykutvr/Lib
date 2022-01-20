using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     Convert object to json string for this collection.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <returns>An enumerator that allows foreach to be used to process for each in this collection.</returns>
    public static string ToJson<T>(this IEnumerable<T> @this)
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(@this);
    }
}
