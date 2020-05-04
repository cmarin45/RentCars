using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCars.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RentCars.Models;

namespace RentCars.Controllers
{
    [Route("api/[controller]")]
    public class RentController : ControllerBase
    {
        private readonly IRentRepository _repository;
        private readonly IMapper _mapper;

        public RentController(IRentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<RentModel[]>> Get()
        {
            try
            {
                var results = await _repository.GetAllRentsAsync(); 
                return _mapper.Map<RentModel[]>(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Fail");
            }
        }
        [HttpGet("{model}")]
        public async Task<ActionResult<RentModel>> Get(string model)
        {
            try
            {
                var result = await _repository.GetRentAsync(model);
                if (result == null) return NotFound();
                return _mapper.Map<RentModel>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Fail");
            }
        }
    }
}
