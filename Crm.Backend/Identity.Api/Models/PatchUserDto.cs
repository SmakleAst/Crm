using AutoMapper;
using Identity.Application.Common.Mappings;
using Identity.Application.Users.Commands.PatchUser;

namespace Identity.Api.Models
{
    public class PatchUserDto : IMapWith<PatchUserCommand>
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PatchUserCommand, PatchUserDto>()
                .ForMember(patchUserDto => patchUserDto.Id,
                    opt => opt.MapFrom(patchUserCommand => patchUserCommand.Id))
                .ForMember(patchUserDto => patchUserDto.Email,
                    opt => opt.MapFrom(patchUserCommand => patchUserCommand.Email))
                .ForMember(patchUserDto => patchUserDto.Password,
                    opt => opt.MapFrom(patchUserCommand => patchUserCommand.Password));
        }
    }
}
