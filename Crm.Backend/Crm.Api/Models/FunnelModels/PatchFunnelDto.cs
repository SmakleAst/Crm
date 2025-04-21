using AutoMapper;
using Crm.Application.Common.Mappings;
using Crm.Application.Funnels.Commands.PatchFunnel;

namespace Crm.Api.Models.FunnelModels
{
    public class PatchFunnelDto : IMapWith<PatchFunnelCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PatchFunnelDto, PatchFunnelCommand>()
                .ForMember(patchFunnelCommand => patchFunnelCommand.Id,
                    opt => opt.MapFrom(patchFunnelDto => patchFunnelDto.Id))
                .ForMember(patchFunnelCommand => patchFunnelCommand.Name,
                    opt => opt.MapFrom(patchFunnelDto => patchFunnelDto.Name));
        }
    }
}
