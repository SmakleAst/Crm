using MediatR;

namespace Crm.Application.Notes.Commands.PatchNote
{
    public class PatchNoteCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Details { get; set; }
        public Guid? ClientId { get; set; }
    }
}
