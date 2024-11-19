using System;

namespace Assignment6
{
    abstract class Equipment
    {
        public string Name { get; set; }
        public string Description { get; set; }
        protected int DistanceMovedTillDate { get; set; } = 0;
        protected int MaintenanceCost { get; set; } = 0;
        public string TypeOfEquipment { get; set; }

        public Equipment(string name, string description, string typeOfEquipment)
        {
            Name = name;
            Description = description;
            TypeOfEquipment = typeOfEquipment;
            DistanceMovedTillDate = 0;
            MaintenanceCost = 0;
        }

        public abstract void MoveBy(int distance);

        public abstract void ShowDetails();
    }

    class MobileEquipment : Equipment
    {
        public int NumberOfWheels;

        public MobileEquipment(string name, string description, string typeOfEquipment, int numberOfWheels)
            : base(name, description, typeOfEquipment)
        {
            NumberOfWheels = numberOfWheels;
        }

        public override void MoveBy(int distance)
        {
            DistanceMovedTillDate += distance;
            MaintenanceCost += NumberOfWheels * distance;
        }

        public override void ShowDetails()
        {
            Console.WriteLine("Details of Equipment:");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"DistanceMovedTillDate: {DistanceMovedTillDate}");
            Console.WriteLine($"MaintenanceCost: {MaintenanceCost}");
            Console.WriteLine($"TypeOfEquipment: {TypeOfEquipment}");
            Console.WriteLine($"NumberOfWheels: {NumberOfWheels}");
            Console.WriteLine("\n");
        }
    }

    class ImmobileEquipment : Equipment
    {
        public int Weight;

        public ImmobileEquipment(string name, string description, string typeOfEquipment, int weight)
            : base(name, description, typeOfEquipment)
        {
            Weight = weight;
        }

        public override void MoveBy(int distance)
        {
            DistanceMovedTillDate += distance;
            MaintenanceCost += Weight * distance;
        }

        public override void ShowDetails()
        {
            Console.WriteLine("Details of Equipment:");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"DistanceMovedTillDate: {DistanceMovedTillDate}");
            Console.WriteLine($"MaintenanceCost: {MaintenanceCost}");
            Console.WriteLine($"TypeOfEquipment: {TypeOfEquipment}");
            Console.WriteLine($"Weight: {Weight}");
        }
    }

    class Program
    {
        public static void Main()
        {
            var equipments = new List<Equipment>();
            equipments.Add(new MobileEquipment("JCB", "Construction Vehicle", "Mobile", 10));
            equipments.Add(new ImmobileEquipment("Ladder", "Stair to climb", "Immobile", 40));
            equipments.Add(new MobileEquipment("Truck", "Carry Transport Vehicle", "Mobile", 50));
            equipments.Add(new ImmobileEquipment("Brush", "Brush to paint", "Immobile", 100));

            var equipmentsToMove = new List<int>();
            equipmentsToMove.Add(0);
            equipmentsToMove.Add(2);

            foreach (var index in equipmentsToMove)
            {
                equipments[index].MoveBy(10);
            }

            Console.WriteLine("Equipments that has not been moved till now");
            for (var index = 0; index < equipments.Count; index++)
            {
                if (!equipmentsToMove.Contains(index))
                {
                    equipments[index].ShowDetails();
                }
            }

            Console.WriteLine("\nName and Description of all the equipments:");
            foreach (var equipment in equipments)
            {
                Console.WriteLine(equipment.Name);
                Console.WriteLine(equipment.Description);
            }

            Console.WriteLine("\nAll details of all the equipments:");
            foreach (var equipment in equipments)
            {
                equipment.ShowDetails();
            }

            Console.WriteLine("\nMobile Equipments:");
            foreach (var equipment in equipments.Where(e => e.TypeOfEquipment.Equals("Mobile")))
            {
                equipment.ShowDetails();
            }

            Console.WriteLine("\nImmobile Equipments:");
            foreach (var equipment in equipments.Where(e => e.TypeOfEquipment.Equals("Immobile")))
            {
                equipment.ShowDetails();
            }

            // Removing all the immobile equipments
            equipments.RemoveAll(e => e.TypeOfEquipment.Equals("Mobile"));

            // Removing all the immobile equipments
            equipments.RemoveAll(e => e.TypeOfEquipment.Equals("Immobile"));

            // Removing all the equipments
            equipments.Clear();
        }
    }
}
