using AutoMapper;
using Crm.Application.Common.Mappings;
using Crm.Application.Promotions.Queries.GetPromotionList;
using Crm.Domain.Entities;

namespace Crm.Application.Promotions.Queries.GetPromotionDetails;

public class PromotionDetailsVm : IMapWith<Promotion>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int DiscountPercentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? EditDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<PromotionDetailsVm, Promotion>()
            .ForMember(promotion => promotion.Id,
                opt => opt.MapFrom(promotionVm => promotionVm.Id))
            .ForMember(promotion => promotion.Name,
                opt => opt.MapFrom(promotionVm => promotionVm.Name))
            .ForMember(promotion => promotion.Description,
                opt => opt.MapFrom(promotionVm => promotionVm.Description))
            .ForMember(promotion => promotion.DiscountPercentage,
                opt => opt.MapFrom(promotionVm => promotionVm.DiscountPercentage))
            .ForMember(promotion => promotion.StartDate,
                opt => opt.MapFrom(promotionVm => promotionVm.StartDate))
            .ForMember(promotion => promotion.EndDate,
                opt => opt.MapFrom(promotionVm => promotionVm.EndDate))
            .ForMember(promotion => promotion.CreationDate,
                opt => opt.MapFrom(promotionVm => promotionVm.CreationDate))
            .ForMember(promotion => promotion.EditDate,
                opt => opt.MapFrom(promotionVm => promotionVm.EditDate));
    }
}