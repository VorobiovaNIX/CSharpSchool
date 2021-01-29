using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _001_Queries_LINQ_to_Entities
{
    class Program
    {
        static void Main(string[] args)
        {

            Context dbb = new Context();
            GenerationData(dbb);
            using (Context db = new Context())
            {
                if (db.Phones.Count()==0)
                {

                }

                var phones = (from phone in db.Phones.Include(p => p.Company)
                              where phone.CompanyId == 1
                              select phone).ToList();

                foreach (var phone in phones)
                {
                    Console.WriteLine($"{phone.Name} ({phone.Price}) - {phone.Company?.Name}");
                }
            }
            Console.Read();

            Console.WriteLine(new string ('-',20));

            using (Context db = new Context())
            {
                var phones = db.Phones.Include(p => p.Company).Where(p => p.CompanyId == 1);
                foreach (var phone in phones)
                {
                    Console.WriteLine($"{phone.Name} ({phone.Price}) - {phone.Company?.Name}");
                }
            }
            Console.Read();
        }


        private static void GenerationData(Context db)
        {
            Country USA = new Country() { Name = "USA" };
            Country China = new Country() { Name = "China" };
            db.Countries.Add(USA);

            Company Samsung = new Company { Name = "Samsung", Country = China };
            Company Apple = new Company { Name = "Apple", Country = USA };
            Company Motorola = new Company { Name = "Motorola", Country = USA };
            Company Sony = new Company { Name = "Sony", Country = China };

            db.Companies.AddRange(Samsung, Apple, Motorola, Sony);

            Phone p1 = new Phone { Name = "Samsung Galaxy S8", Price = 50000, Company = Samsung };
            Phone p2 = new Phone { Name = "Samsung Galaxy S7", Price = 42000, Company = Samsung };
            Phone p3 = new Phone { Name = "IPhone 7", Price = 52000, Company = Apple };
            Phone p4 = new Phone { Name = "IPhone 6S", Price = 42000, Company = Apple };
            Phone p5 = new Phone { Name = "IPhone SE", Price = 42000, Company = Apple };
            Phone p6 = new Phone { Name = "IPhone 8", Price = 42000, Company = Apple };
            Phone p7 = new Phone { Name = "IPhone X", Price = 42000, Company = Apple };
            Phone p8 = new Phone { Name = "Motorola Moto Z", Price = 42000, Company = Motorola };
            Phone p9 = new Phone { Name = "Motorola Moto Z2 Force", Price = 42000, Company = Motorola };
            Phone p10 = new Phone { Name = "Motorola Moto Z Play", Price = 42000, Company = Motorola };
            Phone p11 = new Phone { Name = "Motorola Moto Z2 Force", Price = 42000, Company = Motorola };
            Phone p12 = new Phone { Name = "Sony Xperia XZ2 Dual", Price = 42000, Company = Sony };
            Phone p13 = new Phone { Name = "Sony Xperia XZ2 Compact", Price = 42000, Company = Sony };
            Phone p14 = new Phone { Name = "Sony Xperia XA2", Price = 42000, Company = Sony };
            Phone p15 = new Phone { Name = "Samsung Galaxy S9", Price = 42000, Company = Samsung };

            db.Phones.AddRange(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15);
            db.SaveChanges();

        }
    }
}
