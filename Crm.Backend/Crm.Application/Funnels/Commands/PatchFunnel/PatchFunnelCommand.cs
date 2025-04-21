using MediatR;

namespace Crm.Application.Funnels.Commands.PatchFunnel
{
    public class PatchFunnelCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
