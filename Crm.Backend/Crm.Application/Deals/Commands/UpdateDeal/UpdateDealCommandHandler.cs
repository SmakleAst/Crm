using Crm.Application.Common.Exceptions;
using Crm.Application.Interfaces;
using Crm.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Application.Deals.Commands.UpdateDeal
{
    public class UpdateDealCommandHandler : IRequestHandler<UpdateDealCommand, Unit>
    {
        private readonly ICrmDbContext _dbContext;

        public UpdateDealCommandHandler(ICrmDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateDealCommand request, CancellationToken cancellationToken)
        {
            var deal = await _dbContext.Deals
                .FirstOrDefaultAsync(deal => deal.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Deal), request.Id);

            deal.Name = request.Name;
            deal.Details = request.Details;
            deal.Stage = request.Stage;
            deal.UserId = request.UserId;
            deal.ClientId = request.ClientId;
            deal.FunnelId = request.FunnelId;
            deal.EditDate = DateTime.Now;

            _dbContext.Deals.Update(deal);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
