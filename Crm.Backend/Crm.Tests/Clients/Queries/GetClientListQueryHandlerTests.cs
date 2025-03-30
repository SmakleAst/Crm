using AutoMapper;
using Crm.Application.Clients.Queries.GetClientList;
using Crm.Persistence;
using Crm.Tests.Common;
using Shouldly;

namespace Crm.Tests.Clients.Queries
{
    [Collection("QueryCollection")]
    public class GetClientListQueryHandlerTests
    {
        private readonly CrmDbContext Context;
        private readonly IMapper Mapper;

        public GetClientListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async void GetClientListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetClientListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetClientListQuery
                {

                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<ClientListVm>();
            result.Clients.Count.ShouldBe(4);
        }
    }
}
