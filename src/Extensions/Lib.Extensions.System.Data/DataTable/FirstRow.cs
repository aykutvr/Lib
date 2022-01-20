﻿using System;
using System.ComponentModel;
using System.Data;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     A DataTable extension method that return the first row.
    /// </summary>
    /// <param name="this">The table to act on.</param>
    /// <returns>The first row of the table.</returns>
    public static DataRow FirstRow(this DataTable @this)
    {
        return @this.Rows[0];
    }
}
