using Crm.Domain.Enums;
using MediatR;

namespace Crm.Application.Deals.Commands.UpdateDeal
{
    public class UpdateDealCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public Stages Stage { get; set; }
        public Guid UserId { get; set; }
        public Guid ClientId { get; set; }
        public Guid FunnelId { get; set; }
    }
}
