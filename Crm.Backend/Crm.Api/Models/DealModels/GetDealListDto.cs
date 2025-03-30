using AutoMapper;
using Crm.Application.Common.Mappings;
using Crm.Application.Deals.Queries.GetDealList;

namespace Crm.Api.Models.DealModels
{
    public class GetDealListDto : IMapWith<GetDealListQuery>
    {
        public Guid? FunnelId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetDealListDto, GetDealListQuery>()
                .ForMember(getDealListQuery => getDealListQuery.FunnelId,
                    opt => opt.MapFrom(getDealListDto => getDealListDto.FunnelId));
        }
    }
}
