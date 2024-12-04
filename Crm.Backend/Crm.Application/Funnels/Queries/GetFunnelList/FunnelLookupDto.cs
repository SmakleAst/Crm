using AutoMapper;
using Crm.Application.Common.Mappings;
using Crm.Domain.Entities;

namespace Crm.Application.Funnels.Queries.GetFunnelList
{
    public class FunnelLookupDto : IMapWith<Funnel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime CreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Funnel, FunnelLookupDto>()
                .ForMember(funnelDto => funnelDto.Id,
                    opt => opt.MapFrom(funnel => funnel.Id))
                .ForMember(funnelDto => funnelDto.Name,
                    opt => opt.MapFrom(funnel => funnel.Name))
                .ForMember(funnelDto => funnelDto.EditDate,
                    opt => opt.MapFrom(funnel => funnel.EditDate))
                .ForMember(funnelDto => funnelDto.CreationDate,
                    opt => opt.MapFrom(funnel => funnel.CreationDate));
        }
    }
}
