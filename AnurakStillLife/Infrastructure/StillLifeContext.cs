using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure
{
    public class StillLifeContext : DbContext
    {
        public StillLifeContext(DbContextOptions<StillLifeContext> options) : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtType> ArtTypes { get; set; }
        public DbSet<ArtWork> ArtWorks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
