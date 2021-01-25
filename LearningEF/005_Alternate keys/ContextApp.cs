using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _005_Alternate_keys
{
    class ContextApp: DbContext
    {
        public DbSet<User> Users { get; set; }
        public ContextApp()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestDB_005;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasAlternateKey(u => new { u.Passport, u.PhoneNumber }); //- составной альтернативный первичный ключ, который будет требовать уникальности двух столбцов  HasAlternateKey(u => u.Passport); 
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Passport { get; set; }
        public string PhoneNumber { get; set; }
    }
}
