using AutoMapper;
using Crm.Application.Clients.Commands.UpdateClient;
using Crm.Application.Common.Mappings;

namespace Crm.Api.Models.ClientModels
{
    public class UpdateClientDto : IMapWith<UpdateClientCommand>
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
            profile.CreateMap<UpdateClientDto, UpdateClientCommand>()
                .ForMember(updateClientCommand => updateClientCommand.Id,
                    opt => opt.MapFrom(updateClientDto => updateClientDto.Id))
                .ForMember(updateClientCommand => updateClientCommand.ClientCode,
                    opt => opt.MapFrom(updateClientDto => updateClientDto.ClientCode))
                .ForMember(updateClientCommand => updateClientCommand.LastName,
                    opt => opt.MapFrom(updateClientDto => updateClientDto.LastName))
                .ForMember(updateClientCommand => updateClientCommand.Name,
                    opt => opt.MapFrom(updateClientDto => updateClientDto.Name))
                .ForMember(updateClientCommand => updateClientCommand.MiddleName,
                    opt => opt.MapFrom(updateClientDto => updateClientDto.MiddleName))
                .ForMember(updateClientCommand => updateClientCommand.BirthDay,
                    opt => opt.MapFrom(updateClientDto => updateClientDto.BirthDay))
                .ForMember(updateClientCommand => updateClientCommand.Email,
                    opt => opt.MapFrom(updateClientDto => updateClientDto.Email))
                .ForMember(updateClientCommand => updateClientCommand.Phone,
                    opt => opt.MapFrom(updateClientDto => updateClientDto.Phone))
                .ForMember(updateClientCommand => updateClientCommand.PostalCode,
                    opt => opt.MapFrom(updateClientDto => updateClientDto.PostalCode))
                .ForMember(updateClientCommand => updateClientCommand.City,
                    opt => opt.MapFrom(updateClientDto => updateClientDto.City))
                .ForMember(updateClientCommand => updateClientCommand.Country,
                    opt => opt.MapFrom(updateClientDto => updateClientDto.Country));
        }
    }
}
