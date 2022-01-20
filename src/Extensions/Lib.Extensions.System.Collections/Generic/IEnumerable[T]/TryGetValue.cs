using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

public static partial class Extensions
{
    public static bool TryGetValue<T>(this IEnumerable<T> val, Expression<Func<T, bool>> predicate, out T outputVal) where T : class
    {
        outputVal = null;
        if (val == null)
            return false;

        if (val.Any(predicate.Compile()))
        {
            outputVal = val.First(predicate.Compile());
            return true;
        }

        return false;

    }
}
