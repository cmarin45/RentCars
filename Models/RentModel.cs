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
        public string Venue { get; set; }
        public string LocationAddress1 { get; set; }
        public string LocationAddress2 { get; set; }
        public string LocationAddress3 { get; set; }
        public string LocationCityTown { get; set; }
        public string LocationStateProvince { get; set; }
        public string LocationPostalCode { get; set; }
        public string LocationCountry { get; set; }
        public ICollection<AsigurareModel> Price { get; set; }
    }
}
