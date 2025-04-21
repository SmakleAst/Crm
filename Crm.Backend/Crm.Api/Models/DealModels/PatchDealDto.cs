using AutoMapper;
using Crm.Application.Common.Mappings;
using Crm.Application.Deals.Commands.PatchDeal;
using Crm.Domain.Enums;

namespace Crm.Api.Models.DealModels
{
    public class PatchDealDto : IMapWith<PatchDealCommand>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Details { get; set; }
        public Stages? Stage { get; set; }
        public Guid? UserId { get; set; }
        public Guid? ClientId { get; set; }
        public Guid? FunnelId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PatchDealDto, PatchDealCommand>()
                .ForMember(patchDealCommand => patchDealCommand.Id,
                    opt => opt.MapFrom(patchDealDto => patchDealDto.Id))
                .ForMember(patchDealCommand => patchDealCommand.Name,
                    opt => opt.MapFrom(patchDealDto => patchDealDto.Name))
                .ForMember(patchDealCommand => patchDealCommand.Details,
                    opt => opt.MapFrom(patchDealDto => patchDealDto.Details))
                .ForMember(patchDealCommand => patchDealCommand.Stage,
                    opt => opt.MapFrom(patchDealDto => patchDealDto.Stage))
                .ForMember(patchDealCommand => patchDealCommand.UserId,
                    opt => opt.MapFrom(patchDealDto => patchDealDto.UserId))
                .ForMember(patchDealCommand => patchDealCommand.ClientId,
                    opt => opt.MapFrom(patchDealDto => patchDealDto.ClientId))
                .ForMember(patchDealCommand => patchDealCommand.FunnelId,
                    opt => opt.MapFrom(patchDealDto => patchDealDto.FunnelId));
        }
    }
}
