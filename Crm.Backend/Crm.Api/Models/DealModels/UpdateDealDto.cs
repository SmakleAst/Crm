using AutoMapper;
using Crm.Application.Common.Mappings;
using Crm.Application.Deals.Commands.UpdateDeal;
using Crm.Domain.Enums;

namespace Crm.Api.Models.DealModels
{
    public class UpdateDealDto : IMapWith<UpdateDealCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public Stages Stage { get; set; }
        public Guid UserId { get; set; }
        public Guid ClientId { get; set; }
        public Guid FunnelId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateDealDto, UpdateDealCommand>()
                .ForMember(updateDealCommand => updateDealCommand.Id,
                    opt => opt.MapFrom(updateDealDto => updateDealDto.Id))
                .ForMember(updateDealCommand => updateDealCommand.Name,
                    opt => opt.MapFrom(updateDealDto => updateDealDto.Name))
                .ForMember(updateDealCommand => updateDealCommand.Details,
                    opt => opt.MapFrom(updateDealDto => updateDealDto.Details))
                .ForMember(updateDealCommand => updateDealCommand.Stage,
                    opt => opt.MapFrom(updateDealDto => updateDealDto.Stage))
                .ForMember(updateDealCommand => updateDealCommand.UserId,
                    opt => opt.MapFrom(updateDealDto => updateDealDto.UserId))
                .ForMember(updateDealCommand => updateDealCommand.ClientId,
                    opt => opt.MapFrom(updateDealDto => updateDealDto.ClientId))
                .ForMember(updateDealCommand => updateDealCommand.FunnelId,
                    opt => opt.MapFrom(updateDealDto => updateDealDto.FunnelId));
        }
    }
}
