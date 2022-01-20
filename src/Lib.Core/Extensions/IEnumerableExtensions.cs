using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Core.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> AddIfNotContains<T>(this List<T> val, T item)
           => val.AddIf(!val.Contains(item), item);
        public static IEnumerable<T> AddIf<T>(this List<T> val, bool condition, T item)
        {
            if(condition)
                val.Add(item);
            return val;
        }
    }
}
