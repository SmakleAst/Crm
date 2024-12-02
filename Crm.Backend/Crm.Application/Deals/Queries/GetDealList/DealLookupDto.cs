using AutoMapper;
using Crm.Application.Common.Mappings;
using Crm.Domain.Entities;
using Crm.Domain.Enums;

namespace Crm.Application.Deals.Queries.GetDealList
{
    public class DealLookupDto : IMapWith<Deal>
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
            profile.CreateMap<Deal, DealLookupDto>()
                .ForMember(dealDto => dealDto.Name,
                    opt => opt.MapFrom(deal => deal.Name))
                .ForMember(dealDto => dealDto.Details,
                    opt => opt.MapFrom(deal => deal.Details))
                .ForMember(dealDto => dealDto.Stage,
                    opt => opt.MapFrom(deal => deal.Stage))
                .ForMember(dealDto => dealDto.ClientId,
                    opt => opt.MapFrom(deal => deal.ClientId))
                .ForMember(dealDto => dealDto.FunnelId,
                    opt => opt.MapFrom(deal => deal.FunnelId))
                .ForMember(dealDto => dealDto.EditDate,
                    opt => opt.MapFrom(deal => deal.EditDate))
                .ForMember(dealDto => dealDto.CreationDate,
                    opt => opt.MapFrom(deal => deal.CreationDate));
        }
    }
}
