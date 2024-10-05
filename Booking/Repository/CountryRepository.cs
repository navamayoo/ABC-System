using Booking.Data;
using Booking.Models;
using Booking.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Booking.Repository
{
    public class CountryRepository : ICountryRepository
    {

        private readonly ApplicationDbContext _dbContext;
        public CountryRepository(ApplicationDbContext dbContext)
        {
            _dbContext=dbContext;
        }
        public async Task Create(Country country)
        {
            await _dbContext.AddAsync(country);
            await Save();
        }

        public async Task Delete(Country country)
        {
            _dbContext.Countries.Remove(country);
            await Save();
        }


        public async Task<List<Country>> GetAll()
        {
            var countries = await _dbContext.Countries.ToListAsync();
            return countries;
        }

        public async Task<Country> GetById(int id)
        {
            var country = await _dbContext.Countries.FindAsync(id);
            return country;
        }

        public bool IsCountryExsist(string name)
        {
            var result = _dbContext.Countries.AsQueryable().Where(x => x.Name.ToLower().Trim() == name.ToLower().Trim()).Any();
            return result;
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Country country)
        {
            _dbContext.Countries.Update(country);
            await Save();
        }
    }
}
