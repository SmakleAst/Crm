using AutoMapper;
using Crm.Application.Common.Mappings;
using Crm.Domain.Entities;

namespace Crm.Application.Clients.Queries.GetClientList
{
    public class ClientLookupDto : IMapWith<Client>
    {
        public Guid Id { get; set; }
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
            profile.CreateMap<Client, ClientLookupDto>()
                .ForMember(clientDto => clientDto.Id,
                    opt => opt.MapFrom(client => client.Id))
                .ForMember(clientDto => clientDto.ClientCode,
                    opt => opt.MapFrom(client => client.ClientCode))
                .ForMember(clientDto => clientDto.LastName,
                    opt => opt.MapFrom(client => client.LastName))
                .ForMember(clientDto => clientDto.Name,
                    opt => opt.MapFrom(client => client.Name))
                .ForMember(clientDto => clientDto.MiddleName,
                    opt => opt.MapFrom(client => client.MiddleName))
                .ForMember(clientDto => clientDto.BirthDay,
                    opt => opt.MapFrom(client => client.BirthDay))
                .ForMember(clientDto => clientDto.Email,
                    opt => opt.MapFrom(client => client.Email))
                .ForMember(clientDto => clientDto.Phone,
                    opt => opt.MapFrom(client => client.Phone))
                .ForMember(clientDto => clientDto.PostalCode,
                    opt => opt.MapFrom(client => client.PostalCode))
                .ForMember(clientDto => clientDto.City,
                    opt => opt.MapFrom(client => client.City))
                .ForMember(clientDto => clientDto.Country,
                    opt => opt.MapFrom(client => client.Country));
        }
    }
}
