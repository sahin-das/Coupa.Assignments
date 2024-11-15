namespace Assignment12
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            
            Console.WriteLine("Odd numbers: ");
            numbers.Where(n => n % 2 != 0).ToList().ForEach(n => Console.WriteLine(n));
            
            Console.WriteLine("Even numbers: ");
            numbers.Where(n =>
            {
                return n % 2 == 0;
            }).ToList().ForEach(n => Console.WriteLine(n));
            
            var primeNumbers = numbers.Where(delegate (int n)
            {
                if (n <= 1) return true;
                for (var i=2;i<=Math.Sqrt(n);i++)
                {
                    if (n % i == 0) return false;
                }
                return true;
            }).ToList();
            
            primeNumbers.ForEach(n => Console.WriteLine(n));
            
            primeNumbers = numbers.Where(n =>
            {
                if (n <= 1) return true;
                for (var i=2;i<=Math.Sqrt(n);i++)
                {
                    if (n % i == 0) return false;
                }
                return true;
            }).ToList();
            
            primeNumbers.ForEach(n => Console.WriteLine(n));
        }
    }
}
