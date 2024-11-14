using System;

public class Assignment1
{
    public static void Main(string[] args)
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
}
