﻿using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     Returns a  that represents a specified number of milliseconds.
    /// </summary>
    /// <param name="value">A number of milliseconds.</param>
    /// <returns>An object that represents .</returns>
    public static TimeSpan FromMilliseconds(this Double value)
    {
        return TimeSpan.FromMilliseconds(value);
    }
}
