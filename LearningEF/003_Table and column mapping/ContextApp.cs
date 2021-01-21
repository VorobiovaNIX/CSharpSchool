using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _003_Table_and_column_mapping
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
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestDB_003;Trusted_Connection=True;");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                //modelBuilder.Entity<User>().ToTable("People");
                modelBuilder.Entity<User>().ToTable("People", schema: "userstore");
                //modelBuilder.Entity<User>().Property(u => u.Id).HasColumnName("user_id"); // - the same like [Column("user_id")] 

        }

    }

    //[Table("People")] // use data annotation to rename table  
    public class User
    {
        [Column("user_id")] // use data annotation to rename column 
        public int Id { get; set; }
        public string Name { get; set; }
       
    }
    
}
