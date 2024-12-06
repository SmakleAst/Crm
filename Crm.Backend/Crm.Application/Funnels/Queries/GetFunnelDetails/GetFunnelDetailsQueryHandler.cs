using AutoMapper;
using Crm.Application.Common.Exceptions;
using Crm.Application.Interfaces;
using Crm.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Application.Funnels.Queries.GetFunnelDetails
{
    public class GetFunnelDetailsQueryHandler : IRequestHandler<GetFunnelDetailsQuery, FunnelDetailsVm>
    {
        private readonly ICrmDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFunnelDetailsQueryHandler(ICrmDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        
        public async Task<FunnelDetailsVm> Handle(GetFunnelDetailsQuery request, CancellationToken cancellationToken)
        {
            var funnel = await _dbContext.Funnels
                .Include(funnel => funnel.Deals)
                .FirstOrDefaultAsync(funnel => funnel.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Funnel), request.Id);

            return _mapper.Map<FunnelDetailsVm>(funnel);
        }
    }
}
