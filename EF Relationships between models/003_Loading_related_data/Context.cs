using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _003_Loading_related_data
{
    class Context : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestDB_0003;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class Team // main entity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int StadiumId { get; set; }//foreign key
        public Stadium Stadium { get; set; }

        public List<Player> Players { get; set; } // players of team, also navigation property
    }

    public class Player //linked entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TeamId { get; set; } //foreign key
        public Team Team { get; set; } // navigation property - команда игрока 

        public int CountryId { get; set; } //foreign key
        public Country Country { get; set; } //navigation property - страна игрока
    }

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CapitalId { get; set; } //foreign key
        public City Capital { get; set; } // navigation property - столица страны

        public List<Player> Players { get; set; } // players of team 
    }

    public class Stadium
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
