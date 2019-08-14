using System;

namespace DefaultInterfaceMethods
{
    interface IRepository
    {
        public string Get();

        public string About() => "Default implementation of About method";

        //Having a default implementation for a method does NOT enforce classes
        //that implement this interface to provide an implementation (override)
        //for this method
        public string Describe() => "Default implementation of Describe method";

    }

    public class Repository : IRepository
    {
        public string Get() => "Return some data";

        //Overriding About method is possible but not mandatory
        public string About() => "Override About method";
    }

    class Program
    {
        static void Main(string[] args)
        {
            var repository = new Repository() as IRepository;

            Console.WriteLine(repository.About()); // => Override About method

            Console.WriteLine(repository.Describe()); // => Default implementation of Describe method
        }
    }
}
