using AutoMapper;
using Crm.Application.Common.Exceptions;
using Crm.Application.Interfaces;
using Crm.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Application.Deals.Queries.GetDealDetails
{
    public class GetDealDetailsQueryHandler : IRequestHandler<GetDealDetailsQuery, DealDetailsVm>
    {
        private readonly ICrmDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDealDetailsQueryHandler(ICrmDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<DealDetailsVm> Handle(GetDealDetailsQuery request, CancellationToken cancellationToken)
        {
            var deal = await _dbContext.Deals
                .FirstOrDefaultAsync(deal => deal.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Deal), request.Id);

            return _mapper.Map<DealDetailsVm>(deal);
        }
    }
}
