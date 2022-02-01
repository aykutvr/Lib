﻿using System;
using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     An object extension method that converts the @this to a unique identifier.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>@this as a GUID.</returns>
    public static Guid ToGuid(this object @this)
    {
        return new Guid(@this.ToString());
    }
}
