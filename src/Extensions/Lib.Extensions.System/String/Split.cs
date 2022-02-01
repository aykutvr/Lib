using System;
using System.Collections.Generic;

public static partial class Extensions
{
    /// <summary>
    ///     Returns a String array containing the substrings in this string that are delimited by elements of a specified
    ///     String array. A parameter specifies whether to return empty array elements.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <param name="separator">A string that delimit the substrings in this string.</param>
    /// <param name="option">
    ///     (Optional) Specify RemoveEmptyEntries to omit empty array elements from the array returned,
    ///     or None to include empty array elements in the array returned.
    /// </param>
    /// <returns>
    ///     An array whose elements contain the substrings in this string that are delimited by the separator.
    /// </returns>
    public static string[] Split(this string @this, string separator, StringSplitOptions option = StringSplitOptions.None)
    {
        return @this.Split(new[] { separator }, option);
    }

    /// <summary>
    ///     Returns a String array containing the substrings in this string that are delimited by elements of a specified
    ///     String array. A parameter specifies whether to return empty array elements.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <param name="partSize">A string that delimit the substrings in this string.</param>
    /// <param name="splitByWhiteSpace">
    ///    
    ///    
    /// </param>
    /// <returns>
    ///     An array whose elements contain the substrings in this string that are delimited by the separator.
    /// </returns>
    public static List<string> Split(this string @this, int partSize, bool splitByWhiteSpace = true)
    {
        List<string> result = new List<string>();
        if (!@this.Contains(" ") || splitByWhiteSpace == false)
        {
            while (true)
            {
                string appendString = @this.Length > partSize ? @this.Substring(0, partSize) : @this;
                @this = @this.Remove(0, appendString.Length);
                result.Add(appendString);

                if (@this.Length == 0) break;
            }
        }
        else
        {
            string[] words = @this.Split(' ');
            string appendString = "";
            foreach (var item in words)
            {
                if (appendString.Length + item.Length + 1 > partSize)
                {
                    result.Add(appendString);
                    appendString = item;
                }
                else
                    appendString += $" {item}";
            }
            if (!string.IsNullOrEmpty(appendString)) result.Add(appendString);
        }
        return result;

    }
}
