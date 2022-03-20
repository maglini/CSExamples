using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public static class LogicByReference
    {
        public static IEnumerable<T> UnionByReference<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            return first.Union(second);
        }
        
        public static IEnumerable<T> DistinctByReference<T>(this IEnumerable<T> first)
        {
            return first.Distinct();
        }
        
        public static IEnumerable<T> ExceptByReference<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            return first.Except(second);
        }
        
        public static IEnumerable<T> IntersectByReference<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            return first.Intersect(second);
        }
    }
}