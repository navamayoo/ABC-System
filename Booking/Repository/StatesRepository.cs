using Booking.Data;
using Booking.Models;
using Booking.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Booking.Repository
{
    public class StatesRepository : IStatesRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public StatesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateStates(States states)
        {
            await _dbContext.AddAsync(states);
            await Save();
        }

        public async Task DeleteStates(States states)
        {
            _dbContext.States.Remove(states);
            await Save();
        }

        public Task<List<States>> GetAllStates()
        {
            var stateslist = _dbContext.States.ToListAsync();
            return stateslist;
        }

        public async Task<States> GetStatesById(int id)
        {
            var states = await _dbContext.States.FindAsync(id);
            return states;
        }

        public bool IsStatesExsist(string name)
        {
            var result = _dbContext.States.AsQueryable().Where(s => s.Name.ToLower().Trim() == name.ToLower().Trim()).Any();
            return result;
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateStates(States states)
        {
            _dbContext.States.Update(states);
            await Save();
        }

    }
}
