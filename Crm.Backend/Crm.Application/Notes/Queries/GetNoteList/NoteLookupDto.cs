using Crm.Application.Common.Mappings;
using Crm.Domain.Entities;

namespace Crm.Application.Notes.Queries.GetNoteList
{
    public class NoteLookupDto : IMapWith<Note>
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public Guid ClientId { get; set; }
    }
}
