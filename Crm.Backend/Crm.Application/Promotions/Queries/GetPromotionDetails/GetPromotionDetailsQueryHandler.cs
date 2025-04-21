using AutoMapper;
using Crm.Application.Common.Exceptions;
using Crm.Application.Interfaces;
using Crm.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Application.Promotions.Queries.GetPromotionDetails;

public class GetPromotionDetailsQueryHandler : IRequestHandler<GetPromotionDetailsQuery, PromotionDetailsVm>
{
    private readonly ICrmDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public GetPromotionDetailsQueryHandler(ICrmDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<PromotionDetailsVm> Handle(GetPromotionDetailsQuery request, CancellationToken cancellationToken)
    {
        var promotion = await _dbContext.Promotions
            .FirstOrDefaultAsync(promotion => promotion.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Promotion), request.Id);
        
        return _mapper.Map<PromotionDetailsVm>(promotion);
    }
}