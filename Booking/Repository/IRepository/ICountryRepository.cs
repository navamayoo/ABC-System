using Booking.Models;

namespace Booking.Repository.IRepository
{
    //public interface ICountryRepository
    //{
    //    Task<List<Country>> GetAll();
    //    Task<Country> GetById(int id);
    //    Task Create(Country country);
    //    Task Update(Country country);
    //    Task Delete(Country country);
    //    Task Save();
    //    bool IsCountryExsist(string name);
    //}

    public interface ICountryRepository : IGenericRepository<Country>
    {
        Task Update(Country country);
    }
}
