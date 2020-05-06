using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCars.Models
{
    public class ClientDataModel
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string IdNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
