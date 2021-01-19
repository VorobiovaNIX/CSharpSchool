using System;
using System.Collections.Generic;

#nullable disable

namespace SecondAppWithBD
{
    public partial class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string TypeOfVehicle { get; set; }
        public string BodyType { get; set; }
        public string ProducingCountry { get; set; }
        public int StartPrice { get; set; }
        public int EndPrice { get; set; }
    }
}
