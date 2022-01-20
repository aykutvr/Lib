using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Core.Extensions
{
    public static class IDictionaryExtensions
    {
        public static void AddIfNotContains<TKey, TVal>(this IDictionary<TKey, TVal> dicVal, TKey key, TVal value)
        {
            if (!dicVal.ContainsKey(key))
                dicVal.Add(key, value);
        }
    }
}
