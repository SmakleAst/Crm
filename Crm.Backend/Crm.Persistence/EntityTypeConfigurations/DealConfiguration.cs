using Crm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crm.Persistence.EntityTypeConfigurations
{
    public class DealConfiguration : IEntityTypeConfiguration<Deal>
    {
        public void Configure(EntityTypeBuilder<Deal> builder)
        {
            builder.HasKey(deal => deal.Id);
            builder.HasIndex(deal => deal.Id).IsUnique();

            builder.Property(deal => deal.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(deal => deal.Details)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(deal => deal.Stage)
                .IsRequired();

            builder.Property(deal => deal.UserId)
                .IsRequired();

            builder.Property(deal => deal.ClientId)
                .IsRequired();

            builder.Property(deal => deal.FunnelId)
                .IsRequired();

            builder.HasOne(deal => deal.Client)
                .WithMany(client => client.Deals)
                .HasForeignKey(deal => deal.ClientId);

            builder.HasOne(deal => deal.Funnel)
                .WithMany(funnel => funnel.Deals)
                .HasForeignKey(deal => deal.FunnelId);
        }
    }
}
