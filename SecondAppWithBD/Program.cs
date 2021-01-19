using System;
using System.Linq;

namespace SecondAppWithBD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using(TestDBContext context = new TestDBContext())
            {
                var list =context.Cars.ToList();

                foreach (var item in list)
                {
                    Console.WriteLine($"{item.Brand}--{item.Model}--{item.StartYear}--{item.EndYear}");
                }
            }
        }
    }
}
