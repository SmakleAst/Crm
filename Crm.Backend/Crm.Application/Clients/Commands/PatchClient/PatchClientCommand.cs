using MediatR;

namespace Crm.Application.Clients.Commands.PatchClient
{
    public class PatchClientCommand : IRequest<Unit>
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
    }
}
