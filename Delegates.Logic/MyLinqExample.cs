using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp6.Entities;

namespace ConsoleApp6
{
    public static class MyLinqExample
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

        public static void Execute()
        {
            IEnumerable<Person> persons1 = new List<Person>()
            {
                new Person("Jack", Gender.Man,15),
                new Person("John", Gender.Man,25),
                new Person("Fredericka", Gender.Woman,21),
            };

            bool result1 = persons1.MyAll(person => person.Gender == Gender.Woman);
            
            bool result2 = persons1.MyAny(person => person.Gender == Gender.Man);

            IEnumerable<Person> result3 = persons1
                .MySelect(person=>person)
                .MyWhere(person => person.Age > 20); 

            var result4 = persons1
                .MyWhere(person => person.Age > 20)
                .MySelect(person => new {IsAdult = true, Name = person.Name})
                .ToList();
        }

    }
}