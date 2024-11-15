using System;

abstract class Equipement
{
    protected string Name { get; set; }
    protected string Description { get; set; }
    protected int DistanceMovedTillDate { get; set; } = 0;
    protected int MaintenanceCost { get; set; } = 0;
    protected string TypeOfEquipment { get; set; }

    public Equipement(string name, string description, string typeOfEquipment)
    {
        Name = name;
        Description = description;
        TypeOfEquipment = typeOfEquipment;
        DistanceMovedTillDate = 0;
        MaintenanceCost = 0;
    }

    public abstract void MoveBy(int distance);
}

class MobileEquipement : Equipement
{
    private int _NumberOfWheels;

    public MobileEquipement(string name, string description, string typeOfEquipment, int numberOfWheels)
        : base(name, description, typeOfEquipment)
    {
        _NumberOfWheels = numberOfWheels;
    }

    public override void MoveBy(int distance)
    {
        DistanceMovedTillDate += distance;
        MaintenanceCost += _NumberOfWheels * distance;
    }

    public void ShowDeatils()
    {
        Console.WriteLine("Details of Equipement:");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"DistanceMovedTillDate: {DistanceMovedTillDate}");
        Console.WriteLine($"MaintenanceCost: {MaintenanceCost}");
        Console.WriteLine($"TypeOfEquipment: {TypeOfEquipment}");
        Console.WriteLine($"NumberOfWheels: {_NumberOfWheels}");
        Console.WriteLine("\n");
    }
}

internal class ImmobileEquipment : Equipement
{
    private int _Weight;

    public ImmobileEquipment(string name, string description, string typeOfEquipment, int weight)
        : base(name, description, typeOfEquipment)
    {
        _Weight = weight;
    }

    public override void MoveBy(int distance)
    {
        DistanceMovedTillDate += distance;
        MaintenanceCost += _Weight * distance;
    }

    public void ShowDeatils()
    {
        Console.WriteLine("Details of Equipment:");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"DistanceMovedTillDate: {DistanceMovedTillDate}");
        Console.WriteLine($"MaintenanceCost: {MaintenanceCost}");
        Console.WriteLine($"TypeOfEquipment: {TypeOfEquipment}");
        Console.WriteLine($"Weight: {_Weight}");
    }
}

class Program
{
    static void Main()
    {
        var jcb = new MobileEquipement("JCB", "Construction Vehicle", "Mobile", 10);
        var ladder = new ImmobileEquipment("Ladder", "Climbing stair", "Immobile", 50);

        jcb.MoveBy(10);
        ladder.MoveBy(5);

        jcb.ShowDeatils();
        ladder.ShowDeatils();
    }
}
