using AutoMapper;
using Crm.Application.Common.Mappings;
using Crm.Application.Deals.Commands.CreateDeal;
using Crm.Domain.Enums;

namespace Crm.Api.Models.DealModels
{
    public class CreateDealDto : IMapWith<CreateDealCommand>
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public Stages Stage { get; set; }
        public Guid UserId { get; set; }
        public Guid ClientId { get; set; }
        public Guid FunnelId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDealDto, CreateDealCommand>()
                .ForMember(createDealCommand => createDealCommand.Name,
                    opt => opt.MapFrom(createDealDto => createDealDto.Name))
                .ForMember(createDealCommand => createDealCommand.Details,
                    opt => opt.MapFrom(createDealDto => createDealDto.Details))
                .ForMember(createDealCommand => createDealCommand.Stage,
                    opt => opt.MapFrom(createDealDto => createDealDto.Stage))
                .ForMember(createDealCommand => createDealCommand.UserId,
                    opt => opt.MapFrom(createDealDto => createDealDto.UserId))
                .ForMember(createDealCommand => createDealCommand.ClientId,
                    opt => opt.MapFrom(createDealDto => createDealDto.ClientId))
                .ForMember(createDealCommand => createDealCommand.FunnelId,
                    opt => opt.MapFrom(createDealDto => createDealDto.FunnelId));
        }
    }
}
