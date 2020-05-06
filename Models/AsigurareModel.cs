using RentCars.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCars.Models
{
    public class AsigurareModel
    {
    public int AsigId { get; set; }
    public string NumeAsig { get; set; }
    public int Level { get; set; }
    public ClientDataModel ClientData { get; set; }
    }
}