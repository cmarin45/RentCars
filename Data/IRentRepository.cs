using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentCars.Data
{
  public interface IRentRepository
  {
    // General 
    void Add<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;
    Task<bool> SaveChangesAsync();

    // Rents
    Task<Rent[]> GetAllRentsAsync(bool includePrice = false);
    Task<Rent> GetRentAsync(string model, bool includePrice = false);
    Task<Rent[]> GetAllRentsByStartDate(DateTime dateTime, bool includePrice = false);

    // Price
    Task<Asigurare> GetAsigurareByModelAsync(string model, int AsigId, bool includeClientDatas = false);
    Task<Asigurare[]> GetPriceByModelAsync(string model, bool includeClientDatas = false);

    // Clients
    Task<ClientData[]> GetClientDatasByModelAsync(string model);
    Task<ClientData> GetClientDataAsync(int clientId);
    Task<ClientData[]> GetAllClientDatasAsync();
   }
}