using Identity.Application.Interfaces;
using Identity.Domain.Entities;
using Identity.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Identity.Persistence
{
    public class IdentityDbContext : DbContext, IIdentityDbContext
    {
        public DbSet<User> Users { get; set; }

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
