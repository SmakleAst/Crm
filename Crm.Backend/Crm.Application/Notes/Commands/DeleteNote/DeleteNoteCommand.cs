using MediatR;

namespace Crm.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
