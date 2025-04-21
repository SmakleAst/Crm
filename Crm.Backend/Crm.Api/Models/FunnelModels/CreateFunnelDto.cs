using AutoMapper;
using Crm.Application.Common.Mappings;
using Crm.Application.Funnels.Commands.CreateFunnel;

namespace Crm.Api.Models.FunnelModels
{
    public class CreateFunnelDto : IMapWith<CreateFunnelCommand>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateFunnelDto, CreateFunnelCommand>()
                .ForMember(createFunnelCommand => createFunnelCommand.Name,
                    opt => opt.MapFrom(createFunnelDto => createFunnelDto.Name));
        }
    }
}
