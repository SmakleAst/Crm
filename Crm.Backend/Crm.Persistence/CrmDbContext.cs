using Crm.Application.Interfaces;
using Crm.Domain.Entities;
using Crm.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Crm.Persistence
{
    public class CrmDbContext : DbContext, ICrmDbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Funnel> Funnels { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Promotion> Promotions { get; set; }

        public CrmDbContext(DbContextOptions<CrmDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new FunnelConfiguration());
            modelBuilder.ApplyConfiguration(new DealConfiguration());
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
            modelBuilder.ApplyConfiguration(new PromotionConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
