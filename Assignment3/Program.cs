using System;

class Program
{
    static void Main()
    {
        int start = 0, end = 0;

        while (true)
        {
            Console.Write("Enter the first positive integer between 2 and 1000: ");
            bool isStartValid = int.TryParse(Console.ReadLine(), out start);

            Console.Write("Enter the second positive integer between 2 and 1000: ");
            bool isEndValid = int.TryParse(Console.ReadLine(), out end);

            if (!isStartValid || !isEndValid || start < 2 || end < 2 || start > 1000 || end > 1000)
            {
                Console.WriteLine("Invalid input. Please enter integers between 2 and 1000.");
                continue;
            }

            if (start >= end)
            {
                Console.WriteLine("First number should be less than second number.");
                continue;
            }

            break;
        }

        Console.WriteLine($"Prime numbers between {start} and {end}:");
        for (int i = start; i <= end; i++)
        {
            if (IsPrime(i))
            {
                Console.Write(i + " ");
            }
        }
    }

    static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }
}
