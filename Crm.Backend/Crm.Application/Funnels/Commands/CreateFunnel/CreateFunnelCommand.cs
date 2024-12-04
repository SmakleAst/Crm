using MediatR;

namespace Crm.Application.Funnels.Commands.CreateFunnel
{
    public class CreateFunnelCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
