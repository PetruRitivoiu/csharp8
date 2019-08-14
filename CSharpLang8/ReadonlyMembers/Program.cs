using System;

namespace ReadonlyMembers
{
    class Program
    {
        public struct Point
        {
            public double X { get; set; }
            public double Y { get; set; }
            public readonly double Distance => Math.Sqrt(X * X + Y * Y);

            public readonly override string ToString() =>
                $"({X}, {Y}) is {Distance} from the origin";
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
