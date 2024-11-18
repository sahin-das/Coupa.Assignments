namespace Assignment12
{
    class Program
    {
        public static void Main()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            var oddNumbers = numbers.Where(n => n % 2 != 0).ToList();
            Console.WriteLine("Odd Numbers: " + string.Join(", ", oddNumbers));

            var evenNumbers = numbers.Where(n => { return n % 2 == 0; }).ToList();
            Console.WriteLine("Even Numbers: " + string.Join(", ", evenNumbers));

            var primeNumbers = numbers.Where(delegate(int n) { return IsPrime(n); }).ToList();
            Console.WriteLine("Prime Numbers: " + string.Join(", ", primeNumbers));

            var primeNumbersLambda = numbers.Where(n => IsPrime(n)).ToList();
            Console.WriteLine("Prime Numbers (Lambda): " + string.Join(", ", primeNumbersLambda));

            var greaterThanFive = numbers.Where(IsGreaterThanFive).ToList();
            Console.WriteLine("Numbers Greater Than Five: " + string.Join(", ", greaterThanFive));

            var lessThanFive = numbers.Where(new Predicate<int>(IsLessThanFive).Invoke).ToList();
            Console.WriteLine("Numbers Less Than Five: " + string.Join(", ", lessThanFive));

            var multipleOfThree = numbers.Where(new Func<int, bool>(n => n % 3 == 0)).ToList();
            Console.WriteLine("Multiples of 3 (3k): " + string.Join(", ", multipleOfThree));

            var threeKPlusOne = numbers.Where(new Func<int, bool>(delegate(int n) { return n % 3 == 1; })).ToList();
            Console.WriteLine("Numbers 3k + 1: " + string.Join(", ", threeKPlusOne));

            Func<int, bool> threeKPlusTwoDelegate = n => n % 3 == 2;
            var threeKPlusTwo = numbers.Where(threeKPlusTwoDelegate).ToList();
            Console.WriteLine("Numbers 3k + 2: " + string.Join(", ", threeKPlusTwo));

            Predicate<int> isAnyNumber = delegate(int n) { return true; };
            var anything = numbers.Where(new Func<int, bool>(isAnyNumber.Invoke)).ToList();
            Console.WriteLine("Find Anything (All Numbers): " + string.Join(", ", anything));

            Predicate<int> isAnything = AlwaysTrue;
            var anythingMethodGroup = numbers.Where(new Func<int, bool>(isAnything.Invoke)).ToList();
            Console.WriteLine("Find Anything (Method Group): " + string.Join(", ", anythingMethodGroup));
        }

        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (var i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        static bool IsGreaterThanFive(int number) => number > 5;

        static bool IsLessThanFive(int number) => number < 5;

        static bool AlwaysTrue(int number) => true;
    }
}
