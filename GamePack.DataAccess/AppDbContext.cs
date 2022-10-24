using GamePack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamePack.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Game> Games { get; }
    }
}
