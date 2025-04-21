using AutoMapper;
using AutoMapper.QueryableExtensions;
using Crm.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Application.Clients.Queries.GetClientList
{
    public class GetClientListQueryHandler : IRequestHandler<GetClientListQuery, ClientListVm>
    {
        private readonly ICrmDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetClientListQueryHandler(ICrmDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ClientListVm> Handle(GetClientListQuery request, CancellationToken cancellationToken)
        {
            var clients = await _dbContext.Clients
                .ProjectTo<ClientLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new ClientListVm { Clients = clients };
        }
    }
}
