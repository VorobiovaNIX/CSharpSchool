using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _001_Queries_LINQ_to_Entities
{
    class Context : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Country> Countries { get; set; }
        

        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=mobileappdb;Trusted_Connection=True;");
        }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; } //foreign key
        public Country Country { get; set; } // navigation property - столица страны

        public List<Phone> Phones { get; set; } // players of team 
        public Company() // one-to-many relationship 
        {
            Phones = new List<Phone>();
        }
    }

    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }
        public int CompanyId { get; set; } //foreign key
        public Company Company { get; set; } // navigation property - столица страны

    }

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
