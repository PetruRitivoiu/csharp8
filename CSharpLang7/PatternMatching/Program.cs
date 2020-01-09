using System;

namespace PatternMatching
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

    }

    class Motorcycle : Vehicle
    {
        public override int Capacity => 2;

        public override int NumberOfWheels => 2;

        public string TypeOfMotorcycle => "Sport Bike";
    }

    class Bus : Vehicle
    {
        public override int Capacity => 54;

        public override int NumberOfWheels => 8;

        public string BusLine => "381";
    }

    class Program
    {
        public static Vehicle GetVehicle() => new Bus();
        public static void Main(string[] args)
        {
            Vehicle vehicle = GetVehicle();

            #region The verbose way to do Pattern Matching
            if (vehicle.GetType() == typeof(Bus))
            {
                var bus = vehicle as Bus; //We have to do the casting ourselves
                Console.WriteLine($"It's the {bus.BusLine} bus"); // => 381
            }
            #endregion

            #region The more elegant way
            switch (vehicle)
            {
                case Bus v when v.BusLine != "783": //Mind the recursive pattern here
                    Console.WriteLine($"It's the {v.BusLine} bus"); // => 381
                    break;
                case Motorcycle v:
                    Console.WriteLine($"It's a motorcycle of type {v.TypeOfMotorcycle}"); // => Sport Bike
                    break;
                case Car v:
                    Console.WriteLine($"It's a car of type {v.TypeOfCar}"); // => SUV
                    break;
            }
            #endregion
        }
    }
}
