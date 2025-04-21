using AutoMapper;
using Crm.Application.Common.Mappings;
using Crm.Application.Interfaces;
using Crm.Persistence;

namespace Crm.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public CrmDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = CrmContextFactory.Create();
            var configurationBuilder = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(ICrmDbContext).Assembly));
            });
            Mapper = configurationBuilder.CreateMapper();
        }

        public void Dispose()
        {
            CrmContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture>
    {

    }
}
