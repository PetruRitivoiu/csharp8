using System;

namespace StaticLocalFunctions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    internal class App
    {
        public string Name { get; set; }

        public App(string name)
        {
            Name = name;
        }

        public string Compute()
        {
            int constant = 17;

            #region C# 7.0
            string DoTheComputation() => $"{Name}_{constant}";
            #endregion

            #region C# 8.0
            static string DoTheStaticComputation(int constant, string Name) => $"{Name}_{constant}";
            #endregion

            #region computation
            return DoTheStaticComputation(constant, Name);
            #endregion
        }
    }
}
