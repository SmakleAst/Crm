using Crm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crm.Persistence.EntityTypeConfigurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(note => note.Id);
            builder.HasIndex(note => note.Id).IsUnique();

            builder.Property(note => note.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(note => note.Details)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(note => note.ClientId)
                .IsRequired();

            builder.HasOne(note => note.Client)
                .WithMany(client => client.Notes)
                .HasForeignKey(note => note.ClientId);
        }
    }
}
