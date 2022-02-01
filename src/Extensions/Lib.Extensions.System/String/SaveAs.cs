﻿using System.IO;

public static partial class Extensions
{
    /// <summary>
    ///     A string extension method that save the string into a file.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <param name="fileName">Filename of the file.</param>
    /// <param name="append">(Optional) if the text should be appended to file file if it's exists.</param>
    public static void SaveAs(this string @this, string fileName, bool append = false)
    {
        using (TextWriter tw = new StreamWriter(path:fileName, append:append))
        {
            tw.Write(@this);
        }
    }

    /// <summary>
    ///     A string extension method that save the string into a file.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <param name="file">The FileInfo.</param>
    /// <param name="append">(Optional) if the text should be appended to file file if it's exists.</param>
    public static void SaveAs(this string @this, FileInfo file, bool append = false)
    {
        using (TextWriter tw = new StreamWriter(path: file.FullName, append: append))
        {
            tw.Write(@this);
        }

    }
}
