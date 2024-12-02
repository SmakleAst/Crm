using Crm.Application.Common.Exceptions;
using Crm.Application.Interfaces;
using Crm.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Application.Deals.Commands.PatchDeal
{
    public class PatchDealCommandHandler : IRequestHandler<PatchDealCommand, Unit>
    {
        private readonly ICrmDbContext _dbContext;

        public PatchDealCommandHandler(ICrmDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(PatchDealCommand request, CancellationToken cancellationToken)
        {
            var deal = await _dbContext.Deals
                .FirstOrDefaultAsync(deal => deal.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Deal), request.Id);

            deal.Name = request.Name ?? deal.Name;
            deal.Details = request.Details ?? deal.Details;
            deal.Stage = request.Stage ?? deal.Stage;
            deal.UserId = request.UserId ?? deal.UserId;
            deal.ClientId = request.ClientId ?? deal.ClientId;
            deal.FunnelId = request.FunnelId ?? deal.FunnelId;
            deal.EditDate = DateTime.Now;

            _dbContext.Deals.Update(deal);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        } 
    }
}
