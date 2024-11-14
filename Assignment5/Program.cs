using System;

public enum DuckType
{
    Rubber,
    Mallard,
    Redhead
}

interface Duck
{
    public string Weight { get; set; }
    public string NumberOfWings { get; set; }
    public DuckType TypeOfDuck { get; set; }
    void Fly();
    void MakeSound();

    public void ShowDeatils()
    {
        Console.WriteLine("Details of Duck:");
        Console.WriteLine($"Weight: {Weight}");
        Console.WriteLine($"Number Of Wings: {NumberOfWings}");
        Console.WriteLine($"Type Of Duck: {TypeOfDuck}");
        Console.WriteLine("\n");
    }
}

public class RubberDuck : Duck
{
    public string Weight { get; set; }
    public string NumberOfWings { get; set; }
    public DuckType TypeOfDuck { get; set; } = DuckType.Rubber;

    public RubberDuck(string weight, string wings)
    {
        Weight = weight;
        NumberOfWings = wings;
    }

    public void Fly()
    {
        Console.WriteLine("Rubber ducks don’t fly.");
    }

    public void MakeSound()
    {
        Console.WriteLine("Rubber duck squeaks.");
    }
}

public class MallardDuck : Duck
{
    public string Weight { get; set; }
    public string NumberOfWings { get; set; }
    public DuckType TypeOfDuck { get; set; } = DuckType.Mallard;

    public MallardDuck(string weight, string wings)
    {
        Weight = weight;
        NumberOfWings = wings;
    }

    public void Fly()
    {
        Console.WriteLine("Mallard ducks fly fast.");
    }

    public void MakeSound()
    {
        Console.WriteLine("Mallard duck quacks loud.");
    }
}

public class RedheadDuck : Duck
{
    public string Weight { get; set; }
    public string NumberOfWings { get; set; }
    public DuckType TypeOfDuck { get; set; } = DuckType.Redhead;

    public RedheadDuck(string weight, string wings)
    {
        Weight = weight;
        NumberOfWings = wings;
    }

    public void Fly()
    {
        Console.WriteLine("Redhead ducks fly slow.");
    }

    public void MakeSound()
    {
        Console.WriteLine("Redhead duck quacks mildly.");
    }
}

class Program
{
    static void Main()
    {
        Duck rubberDuck = new RubberDuck("0.5 kg", "0");
        Duck mallardDuck = new MallardDuck("1.2 kg", "2");
        Duck redheadDuck = new RedheadDuck("1.5 kg", "2");

        rubberDuck.MakeSound();
        rubberDuck.Fly();
        rubberDuck.ShowDeatils();

        mallardDuck.MakeSound();
        mallardDuck.Fly();
        mallardDuck.ShowDeatils();

        redheadDuck.MakeSound();
        redheadDuck.Fly();
        redheadDuck.ShowDeatils();
    }
}
