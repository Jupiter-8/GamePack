using Microsoft.EntityFrameworkCore;

namespace GamePack.DataAccess
{
    public class AppDbContextFactory
    {
        private readonly Action<DbContextOptionsBuilder> _configureDbContext;

        public AppDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }

        public AppDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>();

            _configureDbContext(options);

            return new AppDbContext(options.Options);
        }
    }
}
