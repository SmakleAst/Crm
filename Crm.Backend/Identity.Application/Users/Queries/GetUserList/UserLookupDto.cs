using AutoMapper;
using Identity.Application.Common.Mappings;
using Identity.Domain.Entities;
using Identity.Domain.Enums;

namespace Identity.Application.Users.Queries.GetUserList
{
    public class UserLookupDto : IMapWith<User>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserLookupDto>()
                .ForMember(userLookupVm => userLookupVm.Email,
                    opt => opt.MapFrom(user => user.Email))
                .ForMember(userLookupVm => userLookupVm.Password,
                    opt => opt.MapFrom(user => user.Password))
                .ForMember(userLookupVm => userLookupVm.Role,
                    opt => opt.MapFrom(user => user.Role));
        }
    }
}
