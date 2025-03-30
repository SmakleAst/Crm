using Crm.Application.Clients.Commands.CreateClient;
using Crm.Tests.Common;
using Microsoft.EntityFrameworkCore;

namespace Crm.Tests.Clients.Commands
{
    public class CreateClientCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateClientCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateClientCommandHandler(Context);
            var clientCode = "ClientCode5";
            var lastName = "LastName5";
            var name = "Name5";
            var middleName = "MiddleName5";

            // Act
            var clientId = await handler.Handle(
                new CreateClientCommand
                {
                    ClientCode = clientCode,
                    LastName = lastName,
                    Name = name,
                    MiddleName = middleName,
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Clients.SingleOrDefaultAsync(client =>
                    client.Id == clientId && client.ClientCode.Equals(clientCode) &&
                    client.LastName.Equals(lastName) && client.Name.Equals(name) &&
                    client.MiddleName.Equals(middleName)));
        }
    }
}
