using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _004_Configuring_keys
{
    public class ContextApp : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ContextApp()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestDB_004;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Number); //.HasName("UsersPrimaryKey") - set up property Number as primary key 

        }

    }

    public class User
    {
        //[Key] // set up property below as primary key 
        public int Number { get; set; }
        public string Name { get; set; }

    }
}
