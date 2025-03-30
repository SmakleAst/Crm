using Crm.Application.Common.Exceptions;
using Crm.Application.Interfaces;
using Crm.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Application.Clients.Commands.CreateClient
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Guid>
    {
        private readonly ICrmDbContext _dbContext;

        public CreateClientCommandHandler(ICrmDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _dbContext.Clients
                .FirstOrDefaultAsync(client => client.ClientCode.ToLower().Equals(request.ClientCode.ToLower()), cancellationToken);

            if (client != null)
            {
                throw new AlreadyExistsException(nameof(Client), request.ClientCode);
            }

            client = new Client
            {
                Id = Guid.NewGuid(),
                ClientCode = request.ClientCode,
                LastName = request.LastName,
                Name = request.Name,
                MiddleName = request.MiddleName,
                BirthDay = request.BirthDay,
                Email = request.Email,
                Phone = request.Phone,
                PostalCode = request.PostalCode,
                City = request.City,
                Country = request.Country,
                CreationDate = DateTime.Now,
            };

            await _dbContext.Clients.AddAsync(client, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return client.Id;
        }
    }
}