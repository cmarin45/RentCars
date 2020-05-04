using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RentCars.Data
{
  public class RentContext : DbContext
  {
    private readonly IConfiguration _config;

    public RentContext(DbContextOptions options, IConfiguration config) : base(options)
    {
      _config = config;
    }

    public DbSet<Rent> Rents { get; set; }
    public DbSet<ClientData> ClientDatas { get; set; }
    public DbSet<Asigurare> Price { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(_config.GetConnectionString("RentCars"));
    }

    protected override void OnModelCreating(ModelBuilder bldr)
    {
      bldr.Entity<Rent>()
        .HasData(new 
        {
            CarId = 1,
            Model = "Golf",
            Marca = "Volkswagen",
            StartDate = new DateTime(2020, 10, 18),
            LocationId = 1,
            Zile = 1
        });

      bldr.Entity<Location>()
        .HasData(new 
        {
          LocationId = 1,
          VenueName = "Otopeni Auto",
          Address1 = "Calea Bucurestilor 210",
          CityTown = "Otopeni",
          StateProvince = "IF",
          PostalCode = "12345",
          Country = "ROU"
        });

      bldr.Entity<Asigurare>()
        .HasData(new 
        {
          AsigId = 1,
          RentId = 1,
          ClientId = 1,
          Title = "Asigurare Premium",
          Level = 1
        },
        new
        {
          AsigId = 2,
          RentId = 1,
          ClientId = 2,
          NumeAsig = "Asigurare Basic",
          Level = 3
        });

      bldr.Entity<ClientData>()
        .HasData(new
        {
          ClientId = 1,
          FirstName = "Cezar",
          LastName = "Marin",
          IdNumber = "963747",
          Address = "Aleea Eprubetei 21-23",
          City = "Bucuresti",
          Phone = "0755356570",
          Email = "marin.cezar45@gmail.com"
        }, new
        {
            ClientId = 2,
            FirstName = "Irina",
            LastName = "Marin",
            IdNumber = "963748",
            Address = "Aleea Eprubetei 21-23",
            City = "Bucuresti",
            Phone = "0755356570",
            Email = "marin.irina@gmail.com"
        }
        );
    }
  }
}
