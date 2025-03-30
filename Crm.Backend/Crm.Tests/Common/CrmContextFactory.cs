using Crm.Domain.Entities;
using Crm.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Crm.Tests.Common
{
    public class CrmContextFactory
    {
        public static Guid ClientIdForDelete = new Guid("6F9619FF-8B86-D011-B42D-00CF4FC964FF");
        public static Guid ClientIdForUpdate = new Guid("8F9619FF-8B86-D011-B42D-00CF4FC964FF");

        public static CrmDbContext Create()
        {
            var options = new DbContextOptionsBuilder<CrmDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new CrmDbContext(options);
            context.Database.EnsureCreated();
            context.Clients.AddRange(
                new Client
                {
                    Id = ClientIdForDelete,
                    ClientCode = "ClientCode1",
                    LastName = "LastName1",
                    Name = "Name1",
                    MiddleName = "MiddleName1",
                    CreationDate = DateTime.Now,
                },
                new Client
                {
                    Id = ClientIdForUpdate,
                    ClientCode = "ClientCode2",
                    LastName = "LastName2",
                    Name = "Name2",
                    MiddleName = "MiddleName2",
                    CreationDate = DateTime.Now,
                },
                new Client
                {
                    Id = Guid.NewGuid(),
                    ClientCode = "ClientCode3",
                    LastName = "LastName3",
                    Name = "Name3",
                    MiddleName = "MiddleName3",
                    CreationDate = DateTime.Now,
                },
                new Client
                {
                    Id = Guid.NewGuid(),
                    ClientCode = "ClientCode4",
                    LastName = "LastName4",
                    Name = "Name4",
                    MiddleName = "MiddleName4",
                    CreationDate = DateTime.Now,
                }
            );

            context.SaveChanges();
            return context;
        }

        public static void Destroy(CrmDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
