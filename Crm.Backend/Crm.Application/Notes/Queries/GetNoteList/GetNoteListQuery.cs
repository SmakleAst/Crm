using MediatR;

namespace Crm.Application.Notes.Queries.GetNoteList
{
    public class GetNoteListQuery : IRequest<NoteListVm>
    {
        public Guid? ClientId { get; set; }
    }
}
