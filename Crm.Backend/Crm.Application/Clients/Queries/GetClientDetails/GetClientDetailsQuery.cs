using MediatR;

namespace Crm.Application.Clients.Queries.GetClientDetails
{
    public class GetClientDetailsQuery : IRequest<ClientDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
