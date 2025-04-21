using MediatR;

namespace Crm.Application.Promotions.Commands.DeletePromotion;

public class DeletePromotionCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}