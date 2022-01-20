using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

public static partial class Extensions
{
    public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> val, bool condition, Expression<Func<T, int, bool>> predicate)
            => condition ? val.Where(predicate.Compile()).ToList() : val;
}
