using System;

namespace Tuples
{
    class Program
    {
        public static (int x, int y) GetCoordinates()
        {
            return (34, 72);
        }

        static void Main(string[] args)
        {
            #region Implicitly typed tuple initialization
            var point = GetCoordinates();

            Console.WriteLine("Implicitly typed tuple initialization");
            Console.WriteLine($"{nameof(point.x)}: {point.x}"); // => 34
            Console.WriteLine($"{nameof(point.y)}: {point.y}"); // => 72
            #endregion

            #region Strongly typed tuple initialization
            (int y1, int x1) point1  = GetCoordinates(); // Positional matching, NOT name matching

            Console.WriteLine("Strongly typed tuple initialization");
            Console.WriteLine($"{nameof(point1.x1)}: {point1.x1}"); // => 72
            Console.WriteLine($"{nameof(point1.y1)}: {point1.y1}"); // => 34
            #endregion;

            #region Strongly typed deconstruction
            (int x2, int y2) = GetCoordinates();

            Console.WriteLine("Strongly typed deconstruction");
            Console.WriteLine($"{nameof(x2)}: {x2}"); // => 34
            Console.WriteLine($"{nameof(y2)}: {y2}"); // => 72
            #endregion

            #region Implicitly typed deconstruction
            var (x3, y3) = GetCoordinates();

            Console.WriteLine("Implicitly typed deconstruction");
            Console.WriteLine($"{nameof(x2)}: {x2}"); // => 34
            Console.WriteLine($"{nameof(y2)}: {y2}"); // => 72
            #endregion

        }
    }
}
