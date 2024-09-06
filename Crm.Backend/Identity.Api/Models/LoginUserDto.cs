using AutoMapper;
using Identity.Application.Common.Mappings;
using Identity.Application.Users.Queries.LoginUser;

namespace Identity.Api.Models
{
    public class LoginUserDto : IMapWith<LoginUserQuery>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoginUserQuery, LoginUserDto>()
                .ForMember(loginUserDto => loginUserDto.Email,
                    opt => opt.MapFrom(loginUserCommand => loginUserCommand.Email))
                .ForMember(loginUserDto => loginUserDto.Password,
                    opt => opt.MapFrom(loginUserCommand => loginUserCommand.Password));
        }
    }
}
