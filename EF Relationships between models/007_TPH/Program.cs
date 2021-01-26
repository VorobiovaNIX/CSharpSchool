using System;
using System.Linq;

namespace _007_TPH
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Context db = new Context())
            {
                User user1 = new User { Name = "Tom" };
                User user2 = new User { Name = "Bob" };

                db.Users.Add(user1);
                db.Users.Add(user2);

                Employee employee = new Employee { Name = "Shon", Salary = 500 };
                db.Employees.Add(employee);

                Manager manager = new Manager { Name = "Robert", Departament = "IT" };
                db.Managers.Add(manager);

                db.SaveChanges();

                var users = db.Users.ToList();
                Console.WriteLine("\n All users");
                foreach (var user in users)
                {
                    Console.WriteLine(user.Name);
                }

                Console.WriteLine("\n All employees");
                foreach (var emp in db.Employees.ToList())
                {
                    Console.WriteLine(emp.Name);
                }

                Console.WriteLine("\n All managers");
                foreach (var manag in db.Managers.ToList())
                {
                    Console.WriteLine(manag.Name);
                }
            }
        }
    }
}
