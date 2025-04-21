using MediatR;

namespace Crm.Application.Promotions.Queries.GetPromotionDetails;

public class GetPromotionDetailsQuery : IRequest<PromotionDetailsVm>
{
    public Guid Id { get; set; }
}