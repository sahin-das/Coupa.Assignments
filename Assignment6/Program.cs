using System;

abstract class Equipement
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int DistanceMovedTillDate { get; set; } = 0;
    public int MaintenanceCost { get; set; } = 0;
    public string TypeOfEquipement { get; set; }

    public Equipement(string name, string description, string typeOfEquipement)
    {
        Name = name;
        Description = description;
        TypeOfEquipement = typeOfEquipement;
        DistanceMovedTillDate = 0;
        MaintenanceCost = 0;
    }

    public abstract void MoveBy(int distance);

    public abstract void ShowDeatils();
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

    public override void ShowDeatils()
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

    public override void ShowDeatils()
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
        List<Equipement> equipements = new List<Equipement>();
        equipements.Add(new MobileEquipement("JCB", "Construction Vehicle", "Mobile", 10));
        equipements.Add(new ImmobileEquipement("Ladder", "Stair to climb", "Immobile", 40));
        equipements.Add(new MobileEquipement("Truck", "Carry Transport Vehicle", "Mobile", 50));
        equipements.Add(new ImmobileEquipement("Brush", "Brush to paint", "Immobile", 100));

        List<int> equipmentsToMove = new List<int>();
        equipmentsToMove.Add(0);
        equipmentsToMove.Add(2);

        foreach (var index in equipmentsToMove)
        {
            equipements[index].MoveBy(10);
        }

        Console.WriteLine("Equipments that has not been moved till now");
        for (int index = 0; index < equipements.Count; index++)
        {
            if(!equipmentsToMove.Contains(index)){
                equipements[index].ShowDeatils();
            }
        }

        Console.WriteLine("\nName and Description of all the equipements:");
        foreach (var equipement in equipements)
        {
            Console.WriteLine(equipement.Name);
            Console.WriteLine(equipement.Description);
        }

        Console.WriteLine("\nAll details of all the equipements:");
        foreach (var equipement in equipements)
        {
            equipement.ShowDeatils();
        }

        Console.WriteLine("\nMobile Equipments:");
        foreach (var equipement in equipements.Where(e => e.TypeOfEquipement.Equals("Mobile")))
        {
            equipement.ShowDeatils();
        }

        Console.WriteLine("\nImmobile Equipments:");
        foreach (var equipement in equipements.Where(e => e.TypeOfEquipement.Equals("Immobile")))
        {
            equipement.ShowDeatils();
        }

        // Removing all the immobile equipments
        equipements.RemoveAll(e => e.TypeOfEquipement.Equals("Mobile"));

        // Removing all the immobile equipments
        equipements.RemoveAll(e => e.TypeOfEquipement.Equals("Immobile"));

        // Removing all the equiments
        equipements.Clear();
    }
}
