using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     Returns a  equivalent to the specified OLE Automation Date.
    /// </summary>
    /// <param name="d">An OLE Automation Date value.</param>
    /// <returns>An object that represents the same date and time as .</returns>
    public static DateTime FromOADate(this Double d)
    {
        return DateTime.FromOADate(d);
    }
}
