using Crm.Application.Common.Exceptions;
using Crm.Application.Interfaces;
using Crm.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Application.Clients.Commands.PatchClient
{
    public class PatchClientCommandHandler : IRequestHandler<PatchClientCommand, Unit>
    {
        private readonly ICrmDbContext _dbContext;

        public PatchClientCommandHandler(ICrmDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(PatchClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _dbContext.Clients
                .FirstOrDefaultAsync(client => client.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Client), request.Id);

            client.ClientCode = client.ClientCode ?? request.ClientCode;
            client.LastName = client.LastName ?? request.LastName;
            client.Name = client.Name ?? request.Name;
            client.MiddleName = client.MiddleName ?? request.MiddleName;
            client.BirthDay = client.BirthDay ?? request.BirthDay;
            client.Email = client.Email ?? request.Email;
            client.Phone = client.Phone ?? request.Phone;
            client.PostalCode = client.PostalCode ?? request.PostalCode;
            client.City = client.City ?? request.City;
            client.Country = client.Country ?? request.Country;

            _dbContext.Clients.Update(client);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
