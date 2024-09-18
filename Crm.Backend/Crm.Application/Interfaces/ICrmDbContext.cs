using Crm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crm.Application.Interfaces
{
    public interface ICrmDbContext
    {
        DbSet<Client> Clients { get; set; }
        DbSet<Funnel> Funnels { get; set; }
        DbSet<Deal> Deals { get; set; }
        DbSet<Note> Notes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
