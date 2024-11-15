using System;

namespace Assignment17
{
    class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {
        }
    }

    class Program
    {
        static int playCount;

        public static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    if (playCount == 5)
                    {
                        Console.WriteLine("You have played this game 5 times.");
                        break;
                    }

                    Console.WriteLine("Enter any number from 1-5:");
                    var userChoice = Convert.ToInt32(Console.ReadLine()); 

                    switch (userChoice)
                    {
                        case 1:
                            Console.WriteLine("Enter even number:");
                            break;
                        case 2:
                            Console.WriteLine("Enter odd number:");
                            break;
                        case 3:
                            Console.WriteLine("Enter a prime number:");
                            break;
                        case 4:
                            Console.WriteLine("Enter a negative number:");
                            break;
                        case 5:
                            Console.WriteLine("Enter zero:");
                            break;
                        default:
                            throw new CustomException("Invalid choice! Please enter a number between 1 and 5.");
                    }
                    
                    var userInput = Console.ReadLine();
                    ValidateInput(userChoice, Convert.ToInt32(userInput));

                    playCount++;
                    Console.WriteLine("Success! You've entered a valid number. Let's try again.\n");
                }
                catch (CustomException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: Invalid input format. Please enter a valid number.");
                }
            }
        }

        private static bool ValidateInput(int choice, int input)
        {
            switch (choice)
            {
                case 1:
                    if (input % 2 != 0) throw new CustomException("Error: The number is not even.");
                    break;
                case 2:
                    if (input % 2 == 0) throw new CustomException("Error: The number is not odd.");
                    break;
                case 3:
                    if (!IsPrime(input)) throw new CustomException("Error: The number is not prime.");
                    break;
                case 4:
                    if (input >= 0) throw new CustomException("Error: The number is not negative.");
                    break;
                case 5:
                    if (input != 0) throw new CustomException("Error: The number is not zero.");
                    break;
                default:
                    throw new CustomException("Invalid choice! Please enter a number between 1 and 5.");
            }

            return true;
        }

        private static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (var i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}