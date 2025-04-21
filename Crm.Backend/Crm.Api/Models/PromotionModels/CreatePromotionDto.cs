using AutoMapper;
using Crm.Application.Common.Mappings;
using Crm.Application.Promotions.Commands.CreatePromotion;

namespace Crm.Api.Models.PromotionModels;

public class CreatePromotionDto : IMapWith<CreatePromotionCommand>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int DiscountPercentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreatePromotionDto, CreatePromotionCommand>()
            .ForMember(createPromotionCommand => createPromotionCommand.Name,
                opt => opt.MapFrom(createPromotionDto => createPromotionDto.Name))
            .ForMember(createPromotionCommand => createPromotionCommand.Description,
                opt => opt.MapFrom(createPromotionDto => createPromotionDto.Description))
            .ForMember(createPromotionCommand => createPromotionCommand.DiscountPercentage,
                opt => opt.MapFrom(createPromotionDto => createPromotionDto.DiscountPercentage))
            .ForMember(createPromotionCommand => createPromotionCommand.StartDate,
                opt => opt.MapFrom(createPromotionDto => createPromotionDto.StartDate))
            .ForMember(createPromotionCommand => createPromotionCommand.EndDate,
                opt => opt.MapFrom(createPromotionDto => createPromotionDto.EndDate));
    }
}