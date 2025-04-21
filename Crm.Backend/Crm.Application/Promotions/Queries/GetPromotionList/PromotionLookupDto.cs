using AutoMapper;
using Crm.Application.Common.Mappings;
using Crm.Domain.Entities;

namespace Crm.Application.Promotions.Queries.GetPromotionList;

public class PromotionLookupDto : IMapWith<Promotion>
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
        profile.CreateMap<PromotionLookupDto, Promotion>()
            .ForMember(promotion => promotion.Id,
                opt => opt.MapFrom(promotionDto => promotionDto.Id))
            .ForMember(promotion => promotion.Name,
                opt => opt.MapFrom(promotionDto => promotionDto.Name))
            .ForMember(promotion => promotion.Description,
                opt => opt.MapFrom(promotionDto => promotionDto.Description))
            .ForMember(promotion => promotion.DiscountPercentage,
                opt => opt.MapFrom(promotionDto => promotionDto.DiscountPercentage))
            .ForMember(promotion => promotion.StartDate,
                opt => opt.MapFrom(promotionDto => promotionDto.StartDate))
            .ForMember(promotion => promotion.EndDate,
                opt => opt.MapFrom(promotionDto => promotionDto.EndDate))
            .ForMember(promotion => promotion.CreationDate,
                opt => opt.MapFrom(promotionDto => promotionDto.CreationDate))
            .ForMember(promotion => promotion.EditDate,
                opt => opt.MapFrom(promotionDto => promotionDto.EditDate));
    }
}