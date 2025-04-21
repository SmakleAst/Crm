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
            profile.CreateMap<UpdateUserDto, UpdateUserCommand>()
                .ForMember(updateUserCommand => updateUserCommand.Id,
                    opt => opt.MapFrom(updateUserDto => updateUserDto.Id))
                .ForMember(updateUserCommand => updateUserCommand.Email,
                    opt => opt.MapFrom(updateUserDto => updateUserDto.Email))
                .ForMember(updateUserCommand => updateUserCommand.Password,
                    opt => opt.MapFrom(updateUserDto => updateUserDto.Password));
        }
    }
}
