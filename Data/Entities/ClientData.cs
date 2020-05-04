using System.ComponentModel.DataAnnotations;

namespace RentCars.Data
{
   public class ClientData
   {
        [Key]
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