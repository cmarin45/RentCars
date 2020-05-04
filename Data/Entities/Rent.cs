using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentCars.Data
{
  public class Rent
  {
        [Key]
    public int CarId { get; set; }
    public string Marca { get; set; }
    public string Model { get; set; }
    public Location Location { get; set; }
    public DateTime StartDate { get; set; } = DateTime.MinValue;
    public int Zile { get; set; } = 1;
    public ICollection<Asigurare> Price { get; set; }
  }
}