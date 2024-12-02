using MediatR;

namespace Crm.Application.Deals.Commands.DeleteDeal
{
    public class DeleteDealCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
