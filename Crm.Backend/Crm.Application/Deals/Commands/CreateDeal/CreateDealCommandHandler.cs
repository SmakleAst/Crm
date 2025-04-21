using AutoMapper;
using Crm.Application.Interfaces;
using Crm.Domain.Entities;
using MediatR;

namespace Crm.Application.Deals.Commands.CreateDeal
{
    public class CreateDealCommandHandler : IRequestHandler<CreateDealCommand, Guid>
    {
        private readonly ICrmDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateDealCommandHandler(ICrmDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Guid> Handle(CreateDealCommand request, CancellationToken cancellationToken)
        {
            var deal = new Deal
            {
                Name = request.Name,
                Details = request.Details,
                Stage = request.Stage,
                UserId = request.UserId,
                ClientId = request.ClientId,
                FunnelId = request.FunnelId,
                CreationDate = DateTime.Now,
            };

            await _dbContext.Deals.AddAsync(deal, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return deal.Id;
        }
    }
}
