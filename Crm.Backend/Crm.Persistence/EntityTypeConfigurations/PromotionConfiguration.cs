using Crm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crm.Persistence.EntityTypeConfigurations;

public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
{
    public void Configure(EntityTypeBuilder<Promotion> builder)
    {
        builder.HasKey(promotion => promotion.Id);
        builder.HasIndex(promotion => promotion.Id).IsUnique();

        builder.Property(promotion => promotion.Name)
            .IsRequired()
            .HasMaxLength(20);
        
        builder.Property(promotion => promotion.Description)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(promotion => promotion.DiscountPercentage).IsRequired();

        builder.Property(promotion => promotion.StartDate).IsRequired();

        builder.Property(promotion => promotion.EndDate).IsRequired();
    }
}