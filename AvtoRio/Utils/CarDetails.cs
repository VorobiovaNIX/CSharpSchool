using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvtoRio.Utils
{
    public class CarDetails
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }

        public string TypeOfVehicle { get; set; }
        public string BodyType  { get; set; }
        public string ProducingCountry { get; set; }

        public int StartPrice { get; set; }
  
        public int EndPrice { get; set; }


    }

    class AppContext : DbContext
    {
        public DbSet<CarDetails> Cars { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=TestDB; Trusted_Connection=True");
        }
    }
        
}
