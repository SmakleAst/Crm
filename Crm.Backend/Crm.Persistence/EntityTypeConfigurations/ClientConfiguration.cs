using Crm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crm.Persistence.EntityTypeConfigurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(client => client.Id);
            builder.HasIndex(client => client.Id).IsUnique();

            builder.Property(client => client.ClientCode)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(client => client.LastName)
                .HasMaxLength(50);

            builder.Property(client => client.Name)
                .HasMaxLength(50);

            builder.Property(client => client.MiddleName)
                .HasMaxLength(50);

            builder.Property(client => client.Email)
                .HasMaxLength(30);

            builder.Property(client => client.MiddleName)
                .HasMaxLength(11);

            builder.Property(client => client.PostalCode)
                .HasMaxLength(100);

            builder.Property(client => client.City)
                .HasMaxLength(20);

            builder.Property(client => client.Country)
                .HasMaxLength(50);

            builder.HasMany(client => client.Deals)
                .WithOne(deal => deal.Client)
                .HasForeignKey(deal => deal.ClientId);

            builder.HasMany(client => client.Notes)
                .WithOne(note => note.Client)
                .HasForeignKey(note => note.ClientId);
        }
    }
}
