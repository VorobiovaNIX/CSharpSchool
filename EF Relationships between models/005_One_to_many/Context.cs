using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _005_One_to_many
{
    class Context : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestDB_0005;Trusted_Connection=True;");
        }


    }

    public class Team 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Player> Players { get; set; } //  navigation property
    }

    public class Player 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; } //foreign key
        public Team Team { get; set; } //navigation property - страна игрока
    }
}
