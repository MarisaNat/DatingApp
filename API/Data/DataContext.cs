using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        //Photos sollen nicht einzelnen abgefragt werden, sondern immer direkt dem User als Collection angehängt werden, daher braucht es kein eigenes DbSet für Photos
    }
}
