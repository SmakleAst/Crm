using AutoMapper;
using Crm.Application.Common.Exceptions;
using Crm.Application.Interfaces;
using Crm.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Application.Clients.Queries.GetClientDetails
{
    public class GetClientDetailsQueryHandler : IRequestHandler<GetClientDetailsQuery, ClientDetailsVm>
    {
        private readonly ICrmDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetClientDetailsQueryHandler(ICrmDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ClientDetailsVm> Handle(GetClientDetailsQuery request, CancellationToken cancellationToken)
        {
            var client = await _dbContext.Clients
                .Include(client => client.Deals)
                .Include(client => client.Notes)
                .FirstOrDefaultAsync(client => client.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Client), request.Id);

            return _mapper.Map<ClientDetailsVm>(client);
        }
    }
}
