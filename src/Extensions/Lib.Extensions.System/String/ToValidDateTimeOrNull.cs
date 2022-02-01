using System;

public static partial class Extensions
{
    /// <summary>
    /// A string extension method that converts the @this to a valid date time or null.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>@this as a DateTime?</returns>
    public static DateTime? ToValidDateTimeOrNull(this string @this)
    {
        DateTime date;

        if (DateTime.TryParse(@this, out date))
        {
            return date;
        }

        return null;
    }
}
