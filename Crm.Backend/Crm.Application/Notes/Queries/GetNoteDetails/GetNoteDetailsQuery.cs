using MediatR;

namespace Crm.Application.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQuery : IRequest<NoteDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
