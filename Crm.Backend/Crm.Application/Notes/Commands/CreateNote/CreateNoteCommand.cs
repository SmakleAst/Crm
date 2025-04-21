using MediatR;

namespace Crm.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public Guid ClientId { get; set; }
    }
}
