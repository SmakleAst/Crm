using AutoMapper;
using Crm.Application.Common.Mappings;
using Crm.Domain.Entities;
using Crm.Domain.Enums;

namespace Crm.Application.Deals.Queries.GetDealDetails
{
    public class DealDetailsVm : IMapWith<Deal>
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public Stages Stage { get; set; }
        public Guid ClientId { get; set; }
        public Guid FunnelId { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime CreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Deal, DealDetailsVm>()
                .ForMember(dealVm => dealVm.Name,
                    opt => opt.MapFrom(deal => deal.Name))
                .ForMember(dealVm => dealVm.Details,
                    opt => opt.MapFrom(deal => deal.Details))
                .ForMember(dealVm => dealVm.Stage,
                    opt => opt.MapFrom(deal => deal.Stage))
                .ForMember(dealVm => dealVm.ClientId,
                    opt => opt.MapFrom(deal => deal.ClientId))
                .ForMember(dealVm => dealVm.FunnelId,
                    opt => opt.MapFrom(deal => deal.FunnelId))
                .ForMember(dealVm => dealVm.EditDate,
                    opt => opt.MapFrom(deal => deal.EditDate))
                .ForMember(dealVm => dealVm.CreationDate,
                    opt => opt.MapFrom(deal => deal.CreationDate));
        }
    }
}
