using AutoMapper;
using Crm.Application.Common.Mappings;
using Crm.Domain.Entities;

namespace Crm.Application.Funnels.Queries.GetFunnelDetails
{
    public class FunnelDetailsVm : IMapWith<Funnel>
    {
        public string Name { get; set; }
        public IList<Deal> Deals { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime CreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Funnel, FunnelDetailsVm>()
                .ForMember(funnelVm => funnelVm.Name,
                    opt => opt.MapFrom(funnel => funnel.Name))
                .ForMember(funnelVm => funnelVm.Deals,
                    opt => opt.MapFrom(funnel => funnel.Deals))
                .ForMember(funnelVm => funnelVm.EditDate,
                    opt => opt.MapFrom(funnel => funnel.EditDate))
                .ForMember(funnelVm => funnelVm.CreationDate,
                    opt => opt.MapFrom(funnel => funnel.CreationDate));
        }
    }
}
