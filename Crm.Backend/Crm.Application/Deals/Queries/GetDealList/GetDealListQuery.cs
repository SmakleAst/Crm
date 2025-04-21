using MediatR;

namespace Crm.Application.Deals.Queries.GetDealList
{
    public class GetDealListQuery : IRequest<DealListVm>
    {
        public Guid? FunnelId { get; set; }
    }
}
