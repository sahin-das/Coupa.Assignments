using System;

namespace coupa.assignments.Assignments
{
    public class Basics
    {

        public static void Assignment1()
        {
            //Convert to Integer
            Console.WriteLine("Enter an string:");
            string strInput = Console.ReadLine();

            Console.WriteLine("Parsed integer using int.Parse: " + int.Parse(strInput));
            Console.WriteLine("Parsed integer using Convert.ToInt32: " + Convert.ToInt32(strInput));

            int intNumber;
            bool intSuccess = int.TryParse(strInput, out intNumber);
            if (intSuccess)
            {
                Console.WriteLine("Parsed integer using int.TryParse: " + intNumber);
            }
            else
            {
                Console.WriteLine("Invalid input. Could not parse to integer.");
            }

            // Convert to Float
            Console.WriteLine("Enter an floating string:");
            strInput = Console.ReadLine();

            Console.WriteLine("Parsed float using float.Parse: " + float.Parse(strInput));
            Console.WriteLine("Parsed float using Convert.ToSingle: " + Convert.ToSingle(strInput));

            float floatNumber;
            bool floatSuccess = float.TryParse(strInput, out floatNumber);
            if (floatSuccess)
            {
                Console.WriteLine("Parsed float using float.TryParse: " + floatNumber);
            }
            else
            {
                Console.WriteLine("Invalid input. Could not parse to float.");
            }


            // ** Convert to Boolean **
            Console.WriteLine("Enter a boolean string (true/false):");
            string boolInput = Console.ReadLine();
            Console.WriteLine("Parsed boolean using bool.Parse: " + bool.Parse(boolInput));
            Console.WriteLine("Parsed boolean using Convert.ToBoolean: " + Convert.ToBoolean(boolInput));

            bool boolFlag;
            bool boolSuccess = bool.TryParse(boolInput, out boolFlag);
            if (boolSuccess)
            {
                Console.WriteLine("Parsed boolean using bool.TryParse: " + boolFlag);
            }
            else
            {
                Console.WriteLine("Invalid input. Could not parse to boolean.");
            }
        }

        public static void Assignment2()
        {
            object obj1 = new object();
            object obj2 = new object();
            Console.WriteLine(obj1 == obj2);
            // False - reference equality (checks if they refer to the same object)

            string str1 = "hello";
            string str2 = "hello";
            Console.WriteLine(str1.Equals(str2));
            // True - value equality (string overrides Equals to check content)

            object obj3 = new object();
            object obj4 = obj3;
            Console.WriteLine(object.ReferenceEquals(obj3, obj4));
            // True - same reference
        }

        public static void Assignment3()
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
}

