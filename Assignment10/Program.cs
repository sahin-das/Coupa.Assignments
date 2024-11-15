using System;

namespace Assignment10
{
    public static class IntExtensions
    {
        public static bool IsOdd(this int number)
        {
            return number % 2 != 0;
        }

        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }
        
        public static bool IsPrime(this int number)
        {
            if (number <= 1) return false;
            for (var i = 2; i * i <= Math.Sqrt(number); i += 6)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        public static bool IsDivisibleBy(this int number, int divisor)
        {
            if (divisor == 0)
                throw new DivideByZeroException("Divisor cannot be zero.");
            return number % divisor == 0;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            var number = 15;

            Console.WriteLine($"{number} is odd: {number.IsOdd()}");
            Console.WriteLine($"{number} is even: {number.IsEven()}");
            Console.WriteLine($"{number} is prime: {number.IsPrime()}");
            Console.WriteLine($"{number} is divisible by 3: {number.IsDivisibleBy(3)}");
        }
    }
}