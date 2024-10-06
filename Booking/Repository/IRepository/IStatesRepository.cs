using Booking.Models;

namespace Booking.Repository.IRepository
{
    public interface IStatesRepository
    {
        Task<List<States>> GetAllStates();
        Task<States> GetStatesById(int id);
        Task CreateStates(States states);
        Task UpdateStates(States states); 
        Task DeleteStates(States states); 
        bool IsStatesExsist(string name);
        Task Save();
    }
}
