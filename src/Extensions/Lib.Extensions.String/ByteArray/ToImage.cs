using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
#if NETFRAMEWORK
using System.Drawing;
using System.IO;
#endif
public static partial class Extensions
{
#if NETFRAMEWORK
    /// <summary>
    ///     A byte[] extension method that converts the @this to an image.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>@this as an Image.</returns>
    public static Image ToImage(this byte[] @this)
    {
        using (var ms = new MemoryStream(@this))
        {
            return Image.FromStream(ms);
        }
    }
#endif
}
