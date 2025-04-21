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
            profile.CreateMap<LoginUserDto, LoginUserQuery>()
                .ForMember(loginUserCommand => loginUserCommand.Email,
                    opt => opt.MapFrom(loginUserDto => loginUserDto.Email))
                .ForMember(loginUserCommand => loginUserCommand.Password,
                    opt => opt.MapFrom(loginUserDto => loginUserDto.Password));
        }
    }
}
