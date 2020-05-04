using System.ComponentModel.DataAnnotations;

namespace RentCars.Data
{
  public class Asigurare
  {
        [Key]
   public int AsigId { get; set; }
   public Rent Rent { get; set; }
   public string NumeAsig { get; set; }
   public int Level { get; set; }
   public ClientData ClientData { get; set; }
  }
}