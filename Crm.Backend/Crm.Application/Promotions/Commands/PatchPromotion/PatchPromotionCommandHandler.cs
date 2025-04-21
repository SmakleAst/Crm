using Crm.Application.Common.Exceptions;
using Crm.Application.Interfaces;
using Crm.Application.Promotions.Queries.GetPromotionDetails;
using Crm.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Application.Promotions.Commands.PatchPromotion;

public class PatchPromotionCommandHandler : IRequestHandler<PatchPromotionCommand, Unit>
{
    private readonly ICrmDbContext _dbContext;
    
    public PatchPromotionCommandHandler(ICrmDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Unit> Handle(PatchPromotionCommand request, CancellationToken cancellationToken)
    {
        var promotion = await _dbContext.Promotions
            .FirstOrDefaultAsync(promotion => promotion.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Promotion), request.Id);
        
        promotion.Name = request.Name ?? promotion.Name;
        promotion.Description = request.Description ?? promotion.Description;
        promotion.DiscountPercentage = request.DiscountPercentage ?? promotion.DiscountPercentage;
        promotion.StartDate = request.StartDate ?? promotion.StartDate;
        promotion.EndDate = request.EndDate ?? promotion.EndDate;
        promotion.EditDate = DateTime.Now;
        
        _dbContext.Promotions.Update(promotion);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}