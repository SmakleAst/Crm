using MediatR;

namespace Crm.Application.Clients.Commands.DeleteClient
{
    public class DeleteClientCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
