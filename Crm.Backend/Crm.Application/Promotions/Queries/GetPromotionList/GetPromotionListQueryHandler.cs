using AutoMapper;
using AutoMapper.QueryableExtensions;
using Crm.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Application.Promotions.Queries.GetPromotionList;

public class GetPromotionListQueryHandler : IRequestHandler<GetPromotionListQuery, PromotionListVm>
{
    private readonly ICrmDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public GetPromotionListQueryHandler(ICrmDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<PromotionListVm> Handle(GetPromotionListQuery request, CancellationToken cancellationToken)
    {
        var promotions = await _dbContext.Promotions
            .ProjectTo<PromotionLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        
        return new PromotionListVm { Promotions = promotions };
    }
}