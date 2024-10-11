using Booking.Data;
using Booking.Models;
using Booking.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Booking.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {

        private readonly ApplicationDbContext _dbContext;
        public CountryRepository(ApplicationDbContext dbContext): base(dbContext) 
        {
            _dbContext=dbContext;
        }

        public async Task Update(Country country)
        {
            _dbContext.Countries.Update(country);
            await Save();
        }

    }
}
