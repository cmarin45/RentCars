using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RentCars.Models;

namespace RentCars.Data
{
    public class RentProfile : Profile
    {
        public RentProfile()
        {
            this.CreateMap<Rent, RentModel>()
            .ForMember(c => c.Venue, o => o.MapFrom(m => m.Location.VenueName));
        }
    }
}
