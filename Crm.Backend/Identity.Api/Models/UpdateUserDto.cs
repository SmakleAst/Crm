using AutoMapper;
using Identity.Application.Common.Mappings;
using Identity.Application.Users.Commands.UpdateUser;

namespace Identity.Api.Models
{
    public class UpdateUserDto : IMapWith<UpdateUserCommand>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserCommand, UpdateUserDto>()
                .ForMember(updateUserDto => updateUserDto.Id,
                    opt => opt.MapFrom(updateUserCommand => updateUserCommand.Id))
                .ForMember(updateUserDto => updateUserDto.Email,
                    opt => opt.MapFrom(updateUserCommand => updateUserCommand.Email))
                .ForMember(updateUserDto => updateUserDto.Password,
                    opt => opt.MapFrom(updateUserCommand => updateUserCommand.Password));
        }
    }
}
