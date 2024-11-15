using System;

namespace Assignment5
{
    public enum DuckType
    {
        Rubber,
        Mallard,
        Redhead
    }

    internal interface IDuck
    {
        double Weight { get; set; }
        int NumberOfWings { get; set; }
        DuckType TypeOfDuck { get; set; }
        void Fly();
        void MakeSound();
        void ShowDetails();
    }

    public class RubberDuck : IDuck
    {
        public double Weight { get; set; }
        public int NumberOfWings { get; set; }
        public DuckType TypeOfDuck { get; set; } = DuckType.Rubber;

        public RubberDuck(double weight, int wings)
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

        public void ShowDetails()
        {
            Console.WriteLine("Details of Duck:");
            Console.WriteLine($"Weight: {Weight}");
            Console.WriteLine($"Number Of Wings: {NumberOfWings}");
            Console.WriteLine($"Type Of Duck: {TypeOfDuck}\n");
        }
    }

    public class MallardDuck : IDuck
    {
        public double Weight { get; set; }
        public int NumberOfWings { get; set; }
        public DuckType TypeOfDuck { get; set; } = DuckType.Mallard;

        public MallardDuck(double weight, int wings)
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

        public void ShowDetails()
        {
            Console.WriteLine("Details of Duck:");
            Console.WriteLine($"Weight: {Weight}");
            Console.WriteLine($"Number Of Wings: {NumberOfWings}");
            Console.WriteLine($"Type Of Duck: {TypeOfDuck}\n");
        }
    }

    public class RedheadDuck : IDuck
    {
        public double Weight { get; set; }
        public int NumberOfWings { get; set; }
        public DuckType TypeOfDuck { get; set; } = DuckType.Redhead;

        public RedheadDuck(double weight, int wings)
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

        public void ShowDetails()
        {
            Console.WriteLine("Details of Duck:");
            Console.WriteLine($"Weight: {Weight}");
            Console.WriteLine($"Number Of Wings: {NumberOfWings}");
            Console.WriteLine($"Type Of Duck: {TypeOfDuck}\n");
        }
    }

    class Program
    {
        static void Main()
        {
            var rubberDuck = new RubberDuck(0.5, 2);
            var mallardDuck = new MallardDuck(1.5, 4);
            var redheadDuck = new RedheadDuck(1, 3);

            rubberDuck.MakeSound();
            rubberDuck.Fly();
            rubberDuck.ShowDetails();

            mallardDuck.MakeSound();
            mallardDuck.Fly();
            mallardDuck.ShowDetails();

            redheadDuck.MakeSound();
            redheadDuck.Fly();
            redheadDuck.ShowDetails();
        }
    }
}