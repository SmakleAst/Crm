using AutoMapper;
using Identity.Application.Common.Mappings;
using Identity.Application.Users.Queries.GetUserDetails;
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
            profile.CreateMap<User, UserDetailsVm>()
                .ForMember(userDetailsVm => userDetailsVm.Email,
                    opt => opt.MapFrom(user => user.Email))
                .ForMember(userDetailsVm => userDetailsVm.Password,
                    opt => opt.MapFrom(user => user.Password))
                .ForMember(userDetailsVm => userDetailsVm.Role,
                    opt => opt.MapFrom(user => user.Role));
        }
    }
}
