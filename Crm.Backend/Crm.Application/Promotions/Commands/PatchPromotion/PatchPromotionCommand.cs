using MediatR;

namespace Crm.Application.Promotions.Commands.PatchPromotion;

public class PatchPromotionCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? DiscountPercentage { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}