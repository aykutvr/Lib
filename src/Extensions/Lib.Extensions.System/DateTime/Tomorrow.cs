using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     A DateTime extension method that tomorrows the given this.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>Tomorrow date at same time.</returns>
    public static DateTime Tomorrow(this DateTime @this)
    {
        return @this.AddDays(1);
    }
}
