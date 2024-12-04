using MediatR;

namespace Crm.Application.Funnels.Queries.GetFunnelDetails
{
    public class GetFunnelDetailsQuery : IRequest<FunnelDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
