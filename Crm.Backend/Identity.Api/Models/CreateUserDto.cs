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
            profile.CreateMap<CreateUserCommand, CreateUserDto>()
                .ForMember(createUserDto => createUserDto.Email,
                    opt => opt.MapFrom(createUserCommand => createUserCommand.Email))
                .ForMember(createUserDto => createUserDto.Password,
                    opt => opt.MapFrom(createUserCommand => createUserCommand.Password));
        }
    }
}
