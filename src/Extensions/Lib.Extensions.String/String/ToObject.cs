public static partial class Extensions
{
#if NET5_0_OR_GREATER
    /// <summary>
    ///     A string extension method that converts the @this to an enum.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <returns>@this as a T.</returns>
    public static T? ToObject<T>(this string @this)
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(@this);
    }
#else
    /// <summary>
    ///     A string extension method that converts the @this to an enum.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <returns>@this as a T.</returns>
    public static T ToObject<T>(this string @this)
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(@this);
    }
#endif
}
