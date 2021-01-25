using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _007_Property
{
    class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestDB_007;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(b => b.Name).IsRequired();

        }
    }

    public class User
    {
        public int Id { get; set; }
       // [Required]
        public string Name { get; set; }
        public string Passport { get; set; }
        public string PhoneNumber { get; set; }
    }
}
