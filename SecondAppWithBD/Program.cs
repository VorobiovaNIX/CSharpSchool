using System;
using System.Linq;

namespace SecondAppWithBD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Creating items to DB
            using (TestDBContext db = new TestDBContext())
            {
                Car car1 = new Car { Brand = "BMW", Model = "M4" };
                Car car2 = new Car { Brand = "BMW", Model = "435" };
                Car car3 = new Car { Brand = "BMW", Model = "428", StartYear=2015, EndYear=2019 };
                Car car4 = new Car { Brand = "BMW", Model = "M3", StartYear = 2013, EndYear = 2017 };


                db.Cars.Add(car1);
                db.Cars.Add(car2);
                db.Cars.AddRange(car3, car4);
                db.SaveChanges();

            }

            //Getting items from DB
            using (TestDBContext db = new TestDBContext())
            {
                //get object from BD and print it to console
                var cars = db.Cars.ToList();
                Console.WriteLine("Data after creating: ");

                foreach (Car item in cars)
                {
                    Console.WriteLine($"{item.Brand}-- {item.Model}");
                }
            }

            //Editing items
            using (TestDBContext db = new TestDBContext())
            {
                //get the first item
                Car car = db.Cars.FirstOrDefault();
                if (car !=null)
                {
                    car.Brand = "Nissan";
                    car.Model = "Qashqai";
                    //update object
                    db.Cars.Update(car);
                    db.SaveChanges();
                }
                //print data after updating 
                Console.WriteLine("\nData after editing: ");
                var cars = db.Cars.ToList();
                foreach (Car item in cars)
                {
                    Console.WriteLine($"{item.Id}.{item.Brand}--{item.Model}");
                }
            }

            //Deleting 
            using(TestDBContext db = new TestDBContext())
            {
                //get the first item
                Car car = db.Cars.FirstOrDefault();
                if(car!= null)
                {
                    //delete object
                    db.Cars.Remove(car);
                    db.SaveChanges();
                }
                //print data after updating 
                Console.WriteLine("\nData after deleting: ");
                var cars = db.Cars.ToList();
                foreach (Car item in cars)
                {
                    Console.WriteLine($"{item.Id}.{item.Brand} - {item.Model}");
                }
            }

                using (TestDBContext context = new TestDBContext())
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
