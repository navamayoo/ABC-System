using Booking.Models;
using System.Linq.Expressions;

namespace Booking.Repository.IRepository
{
    public interface IGenericRepository<T>where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task Create(T entity);
        Task Delete(T entity);
        Task Save();
        bool IsRecordExsist(Expression<Func<T, bool>> condition);
    }
}
