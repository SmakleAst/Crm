using Crm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crm.Persistence.EntityTypeConfigurations
{
    public class FunnelConfiguration : IEntityTypeConfiguration<Funnel>
    {
        public void Configure(EntityTypeBuilder<Funnel> builder)
        {
            builder.HasKey(funnel => funnel.Id);
            builder.HasIndex(funnel => funnel.Id).IsUnique();

            builder.Property(funnel => funnel.Name)
                .IsRequired()
                .HasMaxLength(40);

            builder.HasMany(funnel => funnel.Deals)
                .WithOne(deal => deal.Funnel)
                .HasForeignKey(deal => deal.FunnelId);
        }
    }
}
