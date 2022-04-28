using System;
using System.Collections.Generic;

namespace Delegates.Logic.Example2
{
    public static class MyLinqExtensions
    {
        public static bool MyAny<TSource>(this IEnumerable<TSource> source, Predicate<TSource> predicate)
        {
            if (source == null)
            {
                throw new ArgumentException();
            }

            if (predicate == null)
            {
                throw new AggregateException();
            }
            
            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool MyAll<TSource>(this IEnumerable<TSource> source, Predicate<TSource> predicate)
        {
            if (source == null)
            {
                throw new ArgumentException();
            }

            if (predicate == null)
            {
                throw new ArgumentException();
            }

            foreach (TSource item in source)
            {
                if (!predicate(item))
                {
                    return false;
                };
            }

            return true;
        } 
        
        public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source, Predicate<TSource> predicate)
        {
            if (source == null)
            {
                throw new AggregateException();
            }

            if (predicate == null)
            {
                throw new ArgumentException();
            }
            
            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
 
        public static IEnumerable<TResult> MySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> func)
        {
            if (source == null)
            {
                throw new ArgumentException();
            }

            if (func == null)
            {
                throw new ArgumentException();
            }
            
            foreach (TSource item in source)
            {
                yield return func(item);
            }
        }
    }
}