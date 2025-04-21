using MediatR;

namespace Crm.Application.Promotions.Commands.CreatePromotion;

public class CreatePromotionCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int DiscountPercentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}