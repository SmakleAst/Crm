using AutoMapper;
using Crm.Application.Clients.Commands.CreateClient;
using Crm.Application.Common.Mappings;

namespace Crm.Api.Models.ClientModels
{
    public class CreateClientDto : IMapWith<CreateClientCommand>
    {
        public string ClientCode { get; set; }
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
            profile.CreateMap<CreateClientDto, CreateClientCommand>()
                .ForMember(createClientCommand => createClientCommand.ClientCode,
                    opt => opt.MapFrom(createClientDto => createClientDto.ClientCode))
                .ForMember(createClientCommand => createClientCommand.LastName,
                    opt => opt.MapFrom(createClientDto => createClientDto.LastName))
                .ForMember(createClientCommand => createClientCommand.Name,
                    opt => opt.MapFrom(createClientDto => createClientDto.Name))
                .ForMember(createClientCommand => createClientCommand.MiddleName,
                    opt => opt.MapFrom(createClientDto => createClientDto.MiddleName))
                .ForMember(createClientCommand => createClientCommand.BirthDay,
                    opt => opt.MapFrom(createClientDto => createClientDto.BirthDay))
                .ForMember(createClientCommand => createClientCommand.Email,
                    opt => opt.MapFrom(createClientDto => createClientDto.Email))
                .ForMember(createClientCommand => createClientCommand.Phone,
                    opt => opt.MapFrom(createClientDto => createClientDto.Phone))
                .ForMember(createClientCommand => createClientCommand.PostalCode,
                    opt => opt.MapFrom(createClientDto => createClientDto.PostalCode))
                .ForMember(createClientCommand => createClientCommand.City,
                    opt => opt.MapFrom(createClientDto => createClientDto.City))
                .ForMember(createClientCommand => createClientCommand.Country,
                    opt => opt.MapFrom(createClientDto => createClientDto.Country));
        }
    }
}
