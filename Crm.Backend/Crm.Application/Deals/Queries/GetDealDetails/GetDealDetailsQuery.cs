using MediatR;

namespace Crm.Application.Deals.Queries.GetDealDetails
{
    public class GetDealDetailsQuery : IRequest<DealDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
