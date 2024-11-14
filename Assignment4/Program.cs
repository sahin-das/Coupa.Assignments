using System;

abstract class Equipement
{
    protected string Name { get; set; }
    protected string Description { get; set; }
    protected int DistanceMovedTillDate { get; set; } = 0;
    protected int MaintenanceCost { get; set; } = 0;
    protected string TypeOfEquipement { get; set; }

    public Equipement(string name, string description, string typeOfEquipement)
    {
        Name = name;
        Description = description;
        TypeOfEquipement = typeOfEquipement;
        DistanceMovedTillDate = 0;
        MaintenanceCost = 0;
    }

    public abstract void MoveBy(int distance);
}

class MobileEquipement : Equipement
{
    public int NumberOfWheels;

    public MobileEquipement(string name, string description, string typeOfEquipement, int numberOfWheels)
        : base(name, description, typeOfEquipement)
    {
        NumberOfWheels = numberOfWheels;
    }

    public override void MoveBy(int distance)
    {
        DistanceMovedTillDate += distance;
        MaintenanceCost += NumberOfWheels * distance;
    }

    public void ShowDeatils()
    {
        Console.WriteLine("Details of Equipement:");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"DistanceMovedTillDate: {DistanceMovedTillDate}");
        Console.WriteLine($"MaintenanceCost: {MaintenanceCost}");
        Console.WriteLine($"TypeOfEquipement: {TypeOfEquipement}");
        Console.WriteLine($"NumberOfWheels: {NumberOfWheels}");
        Console.WriteLine("\n");
    }
}

class ImmobileEquipement : Equipement
{
    public int Weight;

    public ImmobileEquipement(string name, string description, string typeOfEquipement, int weight)
        : base(name, description, typeOfEquipement)
    {
        Weight = weight;
    }

    public override void MoveBy(int distance)
    {
        DistanceMovedTillDate += distance;
        MaintenanceCost += Weight * distance;
    }

    public void ShowDeatils()
    {
        Console.WriteLine("Details of Equipement:");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"DistanceMovedTillDate: {DistanceMovedTillDate}");
        Console.WriteLine($"MaintenanceCost: {MaintenanceCost}");
        Console.WriteLine($"TypeOfEquipement: {TypeOfEquipement}");
        Console.WriteLine($"Weight: {Weight}");
    }
}

class Program
{
    static void Main()
    {
        MobileEquipement jcb = new MobileEquipement("JCB", "Construction Vehicle", "Mobile", 10);
        ImmobileEquipement ladder = new ImmobileEquipement("Ladder", "Climbing stair", "Immobile", 50);

        jcb.MoveBy(10);
        ladder.MoveBy(5);

        jcb.ShowDeatils();
        ladder.ShowDeatils();
    }
}
