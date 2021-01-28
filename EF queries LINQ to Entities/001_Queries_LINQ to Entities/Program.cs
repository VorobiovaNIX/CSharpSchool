using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _001_Queries_LINQ_to_Entities
{
    class Program
    {
        static void Main(string[] args)
        {
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
    }
}
