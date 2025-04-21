using AutoMapper;
using Identity.Application.Common.Mappings;
using Identity.Application.Users.Commands.CreateUser;

namespace Identity.Api.Models
{
    public class CreateUserDto : IMapWith<CreateUserCommand>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserDto, CreateUserCommand>()
                .ForMember(createUserCommand => createUserCommand.Email,
                    opt => opt.MapFrom(createUserDto => createUserDto.Email))
                .ForMember(createUserCommand => createUserCommand.Password,
                    opt => opt.MapFrom(createUserDto => createUserDto.Password));
        }
    }
}
