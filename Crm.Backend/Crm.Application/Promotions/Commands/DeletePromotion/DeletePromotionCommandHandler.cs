using Crm.Application.Common.Exceptions;
using Crm.Application.Interfaces;
using Crm.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Application.Promotions.Commands.DeletePromotion;

public class DeletePromotionCommandHandler : IRequestHandler<DeletePromotionCommand, Unit>
{
    private readonly ICrmDbContext _dbContext;
    
    public DeletePromotionCommandHandler(ICrmDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Unit> Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
    {
        var promotion = await _dbContext.Promotions
            .FirstOrDefaultAsync(promotion => promotion.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Promotion), request.Id);
        
        _dbContext.Promotions.Remove(promotion);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}