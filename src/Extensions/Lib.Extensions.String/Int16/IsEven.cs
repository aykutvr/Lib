﻿using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     An Int32 extension method that query if '@this' is even.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>true if even, false if not.</returns>
    public static bool IsEven(this Int16 @this)
    {
        return @this % 2 == 0;
    }
}
