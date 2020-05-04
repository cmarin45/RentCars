using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCars.Models
{
    public class RentModel
    {
        public string Marca { get; set; }
        public string Model { get; set; }
        public DateTime StartDate { get; set; } = DateTime.MinValue;
        public int Zile { get; set; } = 1;
    }
}
