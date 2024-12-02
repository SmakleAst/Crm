using AutoMapper;
using AutoMapper.QueryableExtensions;
using Crm.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Application.Deals.Queries.GetDealList
{
    public class GetDealListQueryHandler : IRequestHandler<GetDealListQuery, DealListVm>
    {
        private readonly ICrmDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDealListQueryHandler(ICrmDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        
        public async Task<DealListVm> Handle(GetDealListQuery request, CancellationToken cancellationToken)
        {
            var deals = await _dbContext.Deals
                .ProjectTo<DealLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new DealListVm { Deals = deals };
        }
    }
}
