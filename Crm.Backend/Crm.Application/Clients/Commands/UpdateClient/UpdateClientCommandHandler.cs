using Crm.Application.Common.Exceptions;
using Crm.Application.Interfaces;
using Crm.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Application.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Unit>
    {
        private readonly ICrmDbContext _dbContext;

        public UpdateClientCommandHandler(ICrmDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _dbContext.Clients
                .FirstOrDefaultAsync(client => client.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Client), request.Id);

            client.ClientCode = request.ClientCode;
            client.LastName = request.LastName;
            client.Name = request.Name;
            client.MiddleName = request.MiddleName;
            client.BirthDay = request.BirthDay;
            client.Email = request.Email;
            client.Phone = request.Phone;
            client.PostalCode = request.PostalCode;
            client.City = request.City;
            client.Country = request.Country;

            _dbContext.Clients.Update(client);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
