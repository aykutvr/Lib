using System;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     A string extension method that extracts the Decimal from the string.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>The extracted Decimal.</returns>
    public static decimal ExtractDecimal(this string @this)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < @this.Length; i++)
        {
            if (Char.IsDigit(@this[i]) || @this[i] == '.')
            {
                if (sb.Length == 0 && i > 0 && @this[i - 1] == '-')
                {
                    sb.Append('-');
                }
                sb.Append(@this[i]);
            }
        }

        return Convert.ToDecimal(sb.ToString());
    }
}