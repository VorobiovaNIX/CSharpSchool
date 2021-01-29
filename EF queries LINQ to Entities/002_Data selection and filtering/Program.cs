using System;
using System.Linq;

namespace _002_Data_selection_and_filtering
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Where

            Console.WriteLine(new string ('-',15));
            Console.ReadKey();

            using (Context db = new Context())
            {
                var phones = db.Phones.Where(p => p.Company.Name == "Apple");

                foreach (Phone phone in phones)
                {
                    Console.WriteLine($"{ phone.Name} ({phone.Price})");
                }
            }

            Console.WriteLine(new string('-', 15));
            Console.ReadKey();

            using (Context db = new Context())
            {
                var phones = (from phone in db.Phones
                              where phone.Company.Name == "Apple"
                              select phone).ToList();

                foreach (Phone phone in phones)
                {
                    Console.WriteLine($"{ phone.Name} ({phone.Price})");
                }
            }

            #endregion
        }
    }
}
