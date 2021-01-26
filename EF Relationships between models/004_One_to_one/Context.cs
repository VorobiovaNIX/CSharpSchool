using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _004_One_to_one
{
    class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestDB_0004;Trusted_Connection=True;");
        }

        
    }

    public class User // main entity
    {
        public int Id { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }

        public UserProfile Profile { get; set; } //  navigation property
    }

    public class UserProfile //linked entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; } 
        public int UserId { get; set; } //foreign key
        public User User { get; set; } //navigation property - страна игрока
    }
}
