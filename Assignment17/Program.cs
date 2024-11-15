﻿using System;

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
        static int playCount = 0;

        static void Main()
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

                    var message = GetMessageForChoice(userChoice);
                    Console.WriteLine(message);
                    string userInput = Console.ReadLine();

                    ValidateInput(userChoice, userInput);

                    playCount++;
                    Console.WriteLine("Success! You've entered a valid number. Let's try again.\n");

                }
                catch (CustomException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Invalid input format. Please enter a valid number.");
                }
            }
        }

        static string GetMessageForChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    return "Enter even number:";
                case 2:
                    return "Enter odd number:";
                case 3:
                    return "Enter a prime number:";
                case 4:
                    return "Enter a negative number:";
                case 5:
                    return "Enter zero:";
                default:
                    throw new CustomException("Invalid choice! Please enter a number between 1 and 5.");
            }
        }

        static void ValidateInput(int choice, string input)
        {
            switch (choice)
            {
                case 1:
                    if (!IsEven(Convert.ToInt32(input))) throw new CustomException("Error: The number is not even.");
                    break;
                case 2:
                    if (!IsOdd(Convert.ToInt32(input))) throw new CustomException("Error: The number is not odd.");
                    break;
                case 3:
                    if (!IsPrime(Convert.ToInt32(input))) throw new CustomException("Error: The number is not prime.");
                    break;
                case 4:
                    if (!IsNegative(Convert.ToInt32(input)))
                        throw new CustomException("Error: The number is not negative.");
                    break;
                case 5:
                    if (Convert.ToInt32(input) != 0) throw new CustomException("Error: The number is not zero.");
                    break;
                default:
                    throw new CustomException("Invalid choice! Please enter a number between 1 and 5.");
            }
        }

        static bool IsEven(int number) => number % 2 == 0;
        static bool IsOdd(int number) => number % 2 != 0;

        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        static bool IsNegative(int number) => number < 0;
    }
}