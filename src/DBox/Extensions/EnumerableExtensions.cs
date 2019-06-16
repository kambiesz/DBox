using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBox.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool HasElements<T>(this IEnumerable<T> enumerable) => enumerable != null && enumerable.Any();
        public static bool HasElements<T>(this IEnumerable<T> enumerable, Func<T, bool> condition) => enumerable != null && enumerable.Any(condition); 

        public static IEnumerable<IEnumerable<T>> ChunkBy<T>(this IEnumerable<T> enumerable, int chunkSize)
        {
            for (int offset = 0; offset < enumerable.Count(); offset += chunkSize)
            {
                yield return enumerable.Skip(offset).Take(chunkSize);
            }
        }

        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> enumerable, Func<T, TKey> selector, IEqualityComparer<T> comparer = null)
        {
            var set = new HashSet<TKey>();

            if (comparer is null)
            {
                comparer = EqualityComparer<T>.Default;
            }

            return enumerable.Where(i => set.Add(selector(i)));
        }
    }
}
