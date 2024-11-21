using AutoMapper;
using Crm.Application.Common.Mappings;
using Crm.Domain.Entities;

namespace Crm.Application.Clients.Queries.GetClientDetails
{
    public class ClientDetailsVm : IMapWith<Client>
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
        public IList<Deal> Deals { get; set; }
        public IList<Note> Notes { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime CreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Client, ClientDetailsVm>()
                .ForMember(clientVm => clientVm.Id,
                    opt => opt.MapFrom(client => client.Id))
                .ForMember(clientVm => clientVm.ClientCode,
                    opt => opt.MapFrom(client => client.ClientCode))
                .ForMember(clientVm => clientVm.LastName,
                    opt => opt.MapFrom(client => client.LastName))
                .ForMember(clientVm => clientVm.Name,
                    opt => opt.MapFrom(client => client.Name))
                .ForMember(clientVm => clientVm.MiddleName,
                    opt => opt.MapFrom(client => client.MiddleName))
                .ForMember(clientVm => clientVm.BirthDay,
                    opt => opt.MapFrom(client => client.BirthDay))
                .ForMember(clientVm => clientVm.Email,
                    opt => opt.MapFrom(client => client.Email))
                .ForMember(clientVm => clientVm.Phone,
                    opt => opt.MapFrom(client => client.Phone))
                .ForMember(clientVm => clientVm.PostalCode,
                    opt => opt.MapFrom(client => client.PostalCode))
                .ForMember(clientVm => clientVm.City,
                    opt => opt.MapFrom(client => client.City))
                .ForMember(clientVm => clientVm.Country,
                    opt => opt.MapFrom(client => client.Country))
                .ForMember(clientVm => clientVm.Deals,
                    opt => opt.MapFrom(client => client.Deals))
                .ForMember(clientVm => clientVm.Notes,
                    opt => opt.MapFrom(client => client.Notes))
                .ForMember(clientVm => clientVm.EditDate,
                    opt => opt.MapFrom(client => client.EditDate))
                .ForMember(clientVm => clientVm.CreationDate,
                    opt => opt.MapFrom(client => client.CreationDate));
        }
    }
}
