using GamePack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamePack.DataAccess
{
    /// <summary>
    /// Database context class for GamePack applictation.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options">DbContext options.</param>
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// DbSet to access Game entites.
        /// </summary>
        public DbSet<Game> Games { get; }

        /// <summary>
        /// DbSet to access Category entites.
        /// </summary>
        public DbSet<Category> Categories { get; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>()
                .HasKey(g => g.Id);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.Category)
                .WithMany(c => c.Games)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
