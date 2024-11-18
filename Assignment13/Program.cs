using System;

namespace Assignment13
{
    public static class EnumerableExtensions
    {
        private static bool CustomAll<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return source.All(predicate);
        }

        private static bool CustomAny<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return source.Any(predicate);
        }

        private static T CustomMax<T>(this IEnumerable<T> source, Func<T, T, int> comparison)
        {
            return source.Aggregate((max, current) => comparison(current, max) > 0 ? current : max);
        }

        private static T CustomMin<T>(this IEnumerable<T> source, Func<T, T, int> comparison)
        {
            return source.Aggregate((min, current) => comparison(current, min) < 0 ? current : min);
        }

        private static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return source.Where(predicate);
        }

        private static IEnumerable<TResult> CustomSelect<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
        {
            return source.Select(selector);
        }
        
        class Program
        {
            public static void Main()
            {
                var numbers = new List<int> { 1, 2, 3, 4, 5 };

                var allGreaterThanZero = numbers.CustomAll(n => n > 0);
                Console.WriteLine(allGreaterThanZero);

                var anyGreaterThanThree = numbers.CustomAny(n => n > 3);
                Console.WriteLine(anyGreaterThanThree);

                var max = numbers.CustomMax((n1, n2) => n1.CompareTo(n2));
                Console.WriteLine(max);

                var min = numbers.CustomMin((n1, n2) => n1.CompareTo(n2));
                Console.WriteLine(min);

                var evenNumbers = numbers.CustomWhere(n => n % 2 == 0);
                Console.WriteLine(string.Join(", ", evenNumbers));

                var squaredNumbers = numbers.CustomSelect(n => n * n);
                Console.WriteLine(string.Join(", ", squaredNumbers));
            }
        }
    }
}