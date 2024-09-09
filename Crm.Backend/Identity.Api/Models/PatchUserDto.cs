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
            profile.CreateMap<PatchUserDto, PatchUserCommand>()
                .ForMember(patchUserCommand => patchUserCommand.Id,
                    opt => opt.MapFrom(patchUserDto => patchUserDto.Id))
                .ForMember(patchUserCommand => patchUserCommand.Email,
                    opt => opt.MapFrom(patchUserDto => patchUserDto.Email))
                .ForMember(patchUserCommand => patchUserCommand.Password,
                    opt => opt.MapFrom(patchUserDto => patchUserDto.Password));
        }
    }
}
