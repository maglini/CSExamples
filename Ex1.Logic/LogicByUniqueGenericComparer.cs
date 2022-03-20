using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public static class LogicByUniqueGenericComparer
    {
        public static IEnumerable<T> UnionByComparer<T>(
            this IEnumerable<T> first, IEnumerable<T> second, IEqualityComparer<T> comparer)
        {
            return first.Union(second, comparer);
        }
        
        public static IEnumerable<T> DistinctByComparer<T>(this IEnumerable<T> first, IEqualityComparer<T> comparer)
        {
            return first.Distinct(comparer);
        }
        
        public static IEnumerable<T> ExceptByComparer<T>(
            this IEnumerable<T> first, IEnumerable<T> second, IEqualityComparer<T> comparer)
        {
            return first.Except(second, comparer);
        }

        public static IEnumerable<T> IntersectByComparer<T>(
            this IEnumerable<T> first, IEnumerable<T> second, IEqualityComparer<T> comparer)
        {
            return first.Intersect(second, comparer);
        }
    }
}