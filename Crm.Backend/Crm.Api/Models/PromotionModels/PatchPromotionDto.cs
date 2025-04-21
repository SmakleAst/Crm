using AutoMapper;
using Crm.Application.Common.Mappings;
using Crm.Application.Promotions.Commands.PatchPromotion;

namespace Crm.Api.Models.PromotionModels;

public class PatchPromotionDto : IMapWith<PatchPromotionCommand>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? DiscountPercentage { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<PatchPromotionDto, PatchPromotionCommand>()
            .ForMember(patchPromotionCommand => patchPromotionCommand.Id,
                opt => opt.MapFrom(patchPromotionDto => patchPromotionDto.Id))
            .ForMember(patchPromotionCommand => patchPromotionCommand.Name,
                opt => opt.MapFrom(patchPromotionDto => patchPromotionDto.Name))
            .ForMember(patchPromotionCommand => patchPromotionCommand.Description,
                opt => opt.MapFrom(patchPromotionDto => patchPromotionDto.Description))
            .ForMember(patchPromotionCommand => patchPromotionCommand.DiscountPercentage,
                opt => opt.MapFrom(patchPromotionDto => patchPromotionDto.DiscountPercentage))
            .ForMember(patchPromotionCommand => patchPromotionCommand.StartDate,
                opt => opt.MapFrom(patchPromotionDto => patchPromotionDto.StartDate))
            .ForMember(patchPromotionCommand => patchPromotionCommand.EndDate,
                opt => opt.MapFrom(patchPromotionDto => patchPromotionDto.EndDate));
    }
}