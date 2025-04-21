using Crm.Application.Common.Exceptions;
using Crm.Application.Interfaces;
using Crm.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Application.Promotions.Commands.CreatePromotion;

public class CreatePromotionCommandHandler : IRequestHandler<CreatePromotionCommand, Guid>
{
    private readonly ICrmDbContext _dbContext;
    
    public CreatePromotionCommandHandler(ICrmDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Guid> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
    {
        var promotion = await _dbContext.Promotions
            .FirstOrDefaultAsync(promotion => promotion.Name.Equals(request.Name), cancellationToken);

        if (promotion != null)
        {
            throw new AlreadyExistsException(nameof(Promotions), request.Name);
        }

        promotion = new Promotion
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            DiscountPercentage = request.DiscountPercentage,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            CreationDate = DateTime.Now,
        };
        
        await _dbContext.Promotions.AddAsync(promotion, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return promotion.Id;
    }
}