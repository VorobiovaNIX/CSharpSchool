using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _002_Cascading_delete
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
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestDB_0002;Trusted_Connection=True;");
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
        public List<Player> Players { get; set; }
    }

    public class Player //linked entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TeamId { get; set; } //foreign key 
        public Team Team { get; set; } // navigation property 
    }
}
