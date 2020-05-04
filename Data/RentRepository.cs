using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace RentCars.Data
{
    public class RentRepository : IRentRepository
    {
        private readonly RentContext _context;
        private readonly ILogger<RentRepository> _logger;

        public RentRepository(RentContext context, ILogger<RentRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Removing an object of type {entity.GetType()} to the context.");
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            _logger.LogInformation($"Attempitng to save the changes in the context");

            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Rent[]> GetAllRentsByStartDate(DateTime dateTime, bool includePrice = false)
        {
            _logger.LogInformation($"Getting all Rents");

            IQueryable<Rent> query = _context.Rents
                .Include(c => c.Location);

            if (includePrice)
            {
                query = query
                  .Include(c => c.Price)
                  .ThenInclude(t => t.ClientData);
            }

            // Order It
            query = query.OrderByDescending(c => c.StartDate)
              .Where(c => c.StartDate.Date == dateTime.Date);

            return await query.ToArrayAsync();
        }

        public async Task<Rent[]> GetAllRentsAsync(bool includePrice = false)
        {
            _logger.LogInformation($"Getting all Rents");

            IQueryable<Rent> query = _context.Rents
                .Include(c => c.Location);

            if (includePrice)
            {
                query = query
                  .Include(c => c.Price)
                  .ThenInclude(t => t.ClientData);
            }

            // Order It
            query = query.OrderByDescending(c => c.StartDate);

            return await query.ToArrayAsync();
        }

        public async Task<Rent> GetRentAsync(string model, bool includePrice = false)
        {
            _logger.LogInformation($"Getting a Rent for {model}");

            IQueryable<Rent> query = _context.Rents
                .Include(c => c.Location);

            if (includePrice)
            {
                query = query.Include(c => c.Price)
                  .ThenInclude(t => t.ClientData);
            }

            // Query It
            query = query.Where(c => c.Model == model);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Asigurare[]> GetPriceByModelAsync(string model, bool includeClientDatas = false)
        {
            _logger.LogInformation($"Getting all Price for a Rent");

            IQueryable<Asigurare> query = _context.Price;

            if (includeClientDatas)
            {
                query = query
                  .Include(t => t.ClientData);
            }

            // Add Query
            query = query
              .Where(t => t.Rent.Model == model)
              .OrderByDescending(t => t.NumeAsig);

            return await query.ToArrayAsync();
        }

        public async Task<Asigurare> GetAsigurareByModelAsync(string model, int AsigId, bool includeClientDatas = false)
        {
            _logger.LogInformation($"Getting all Price for a Rent");

            IQueryable<Asigurare> query = _context.Price;

            if (includeClientDatas)
            {
                query = query
                  .Include(t => t.ClientData);
            }

            // Add Query
            query = query
              .Where(t => t.AsigId == AsigId && t.Rent.Model == model);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<ClientData[]> GetClientDatasByModelAsync(string model)
        {
            _logger.LogInformation($"Getting all ClientData for a Rent");

            IQueryable<ClientData> query = _context.Price
              .Where(t => t.Rent.Model == model)
              .Select(t => t.ClientData)
              .Where(s => s != null)
              .OrderBy(s => s.LastName)
              .Distinct();

            return await query.ToArrayAsync();
        }

        public async Task<ClientData[]> GetAllClientDatasAsync()
        {
            _logger.LogInformation($"Getting ClientData");

            var query = _context.ClientDatas
              .OrderBy(t => t.LastName);

            return await query.ToArrayAsync();
        }


        public async Task<ClientData> GetClientDataAsync(int ClientId)
        {
            _logger.LogInformation($"Getting ClientData");

            var query = _context.ClientDatas
              .Where(t => t.ClientId == ClientId);

            return await query.FirstOrDefaultAsync();
        }

    }
}
