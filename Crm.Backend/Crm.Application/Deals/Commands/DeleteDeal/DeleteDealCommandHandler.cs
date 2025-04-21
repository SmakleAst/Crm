using Crm.Application.Common.Exceptions;
using Crm.Application.Interfaces;
using Crm.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Application.Deals.Commands.DeleteDeal
{
    public class DeleteDealCommandHandler : IRequestHandler<DeleteDealCommand, Unit>
    {
        private readonly ICrmDbContext _dbContext;

        public DeleteDealCommandHandler(ICrmDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteDealCommand request, CancellationToken cancellationToken)
        {
            var deal = await _dbContext.Deals
                .FirstOrDefaultAsync(deal => deal.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Deal), request.Id);

            _dbContext.Deals.Remove(deal);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
