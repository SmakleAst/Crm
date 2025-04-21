using AutoMapper;
using AutoMapper.QueryableExtensions;
using Crm.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Application.Funnels.Queries.GetFunnelList
{
    public class GetFunnelListQueryHandler : IRequestHandler<GetFunnelListQuery, FunnelListVm>
    {
        private readonly ICrmDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFunnelListQueryHandler(ICrmDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        
        public async Task<FunnelListVm> Handle(GetFunnelListQuery request, CancellationToken cancellationToken)
        {
            var funnels = await _dbContext.Funnels
                .ProjectTo<FunnelLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new FunnelListVm { Funnels = funnels };
        }
    }
}
