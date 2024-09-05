using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Interfaces
{
    public interface IIdentityDbContext
    {
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
