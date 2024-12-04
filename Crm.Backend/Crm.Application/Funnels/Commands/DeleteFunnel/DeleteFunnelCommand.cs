using MediatR;

namespace Crm.Application.Funnels.Commands.DeleteFunnel
{
    public class DeleteFunnelCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
