using System;

namespace Recursive_Patterns
{
    abstract class Vehicle
    {
        public abstract int Capacity { get; }
        public abstract int NumberOfWheels { get; }
    }

    class Car : Vehicle
    {
        public override int Capacity => 5;

        public override int NumberOfWheels => 4;

        public string TypeOfCar => "SUV";

        public void Deconstruct(out int capacity, out int numberOfWheels, out string typeOfCar)
        {
            capacity = Capacity;
            numberOfWheels = NumberOfWheels;
            typeOfCar = TypeOfCar;
        }

    }

    class Motorcycle : Vehicle
    {
        public override int Capacity => 2;

        public override int NumberOfWheels => 2;

        public string TypeOfMotorcycle => "Sport Bike";

        public void Deconstruct(out int capacity, out int numberOfWheels, out string typeOfMotorcycle)
        {
            capacity = Capacity;
            numberOfWheels = NumberOfWheels;
            typeOfMotorcycle = TypeOfMotorcycle;
        }
    }

    class Bus : Vehicle
    {
        public override int Capacity => 54;

        public override int NumberOfWheels => 8;

        public string BusLine => "381";

        public void Deconstruct(out int capacity, out int numberOfWheels, out string busLine)
        {
            capacity = Capacity;
            numberOfWheels = NumberOfWheels;
            busLine = BusLine;
        }
    }

    class Program
    {
        public static Vehicle GetVehicle() => new Bus();

        static void Main(string[] args)
        {
            Vehicle vehicle = GetVehicle();

            #region Switch expressions & Recurssive Patterns
            var description = VehicleToString(vehicle);

            Console.WriteLine($"Vehicle pattern matching result: {description}");
            #endregion

            #region Tuple Patterns
            var whoWins = RockPaperScissors("rock", "paper");

            Console.WriteLine($"The winner is: {whoWins}");
            #endregion


        }

        public static string VehicleToString(Vehicle vehicle) => vehicle switch
        {
            Bus b when b.BusLine == "381" => $"Bus {b.BusLine}: First matched by case-when pattern",

            #region Positional Patterns
            Bus(54, 8, _) b => $"Bus {b.BusLine}: First matched by Positional pattern",
            #endregion

            #region Property Patterns
            Bus { Capacity: 54, NumberOfWheels: 8 } b => $"Bus {b.BusLine}: First matched by Property pattern",
            #endregion

            #region Match any vehicle of specified type
            Bus b => $"Bus {b.BusLine}: First matched by MatchAnyOfType pattern",
            #endregion

            #region Match anything
            _ => "You can use _ as a wildcard to match anything"
            #endregion
        };

        public static string RockPaperScissors(string first, string second)
            => (first, second) switch
        {
            ("rock", "paper") => "rock is covered by paper. Paper wins.",
            ("rock", "scissors") => "rock breaks scissors. Rock wins.",
            ("paper", "rock") => "paper covers rock. Paper wins.",
            ("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
            ("scissors", "rock") => "scissors is broken by rock. Rock wins.",
            ("scissors", "paper") => "scissors cuts paper. Scissors wins.",
            (_, _) => "tie"
        };
    }
}
