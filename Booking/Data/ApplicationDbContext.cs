using Booking.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) 
        {
            
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<States> States { get; set; }

        internal void Remove()
        {
            throw new NotImplementedException();
        }
    }
}
