using AutoMapper;
using Crm.Application.Clients.Commands.PatchClient;
using Crm.Application.Common.Mappings;

namespace Crm.Api.Models.ClientModels
{
    public class PatchClientDto : IMapWith<PatchClientCommand>
    {
        public Guid Id { get; set; }
        public string? ClientCode { get; set; }
        public string? LastName { get; set; }
        public string? Name { get; set; }
        public string? MiddleName { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PatchClientDto, PatchClientCommand>()
                .ForMember(patchClientCommand => patchClientCommand.Id,
                    opt => opt.MapFrom(patchClientDto => patchClientDto.Id))
                .ForMember(patchClientCommand => patchClientCommand.ClientCode,
                    opt => opt.MapFrom(patchClientDto => patchClientDto.ClientCode))
                .ForMember(patchClientCommand => patchClientCommand.LastName,
                    opt => opt.MapFrom(patchClientDto => patchClientDto.LastName))
                .ForMember(patchClientCommand => patchClientCommand.Name,
                    opt => opt.MapFrom(patchClientDto => patchClientDto.Name))
                .ForMember(patchClientCommand => patchClientCommand.MiddleName,
                    opt => opt.MapFrom(patchClientDto => patchClientDto.MiddleName))
                .ForMember(patchClientCommand => patchClientCommand.BirthDay,
                    opt => opt.MapFrom(patchClientDto => patchClientDto.BirthDay))
                .ForMember(patchClientCommand => patchClientCommand.Email,
                    opt => opt.MapFrom(patchClientDto => patchClientDto.Email))
                .ForMember(patchClientCommand => patchClientCommand.Phone,
                    opt => opt.MapFrom(patchClientDto => patchClientDto.Phone))
                .ForMember(patchClientCommand => patchClientCommand.PostalCode,
                    opt => opt.MapFrom(patchClientDto => patchClientDto.PostalCode))
                .ForMember(patchClientCommand => patchClientCommand.City,
                    opt => opt.MapFrom(patchClientDto => patchClientDto.City))
                .ForMember(patchClientCommand => patchClientCommand.Country,
                    opt => opt.MapFrom(patchClientDto => patchClientDto.Country));
        }
    }
}
