using AutoMapper;
using Crm.Application.Common.Mappings;
using Crm.Domain.Entities;

namespace Crm.Application.Notes.Queries.GetNoteDetails
{
    public class NoteDetailsVm : IMapWith<Note>
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public Guid ClientId { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime CreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteDetailsVm>()
                .ForMember(noteVm => noteVm.Name,
                    opt => opt.MapFrom(note => note.Name))
                .ForMember(noteVm => noteVm.Details,
                    opt => opt.MapFrom(note => note.Details))
                .ForMember(noteVm => noteVm.ClientId,
                    opt => opt.MapFrom(note => note.ClientId))
                .ForMember(noteVm => noteVm.EditDate,
                    opt => opt.MapFrom(note => note.EditDate))
                .ForMember(noteVm => noteVm.CreationDate,
                    opt => opt.MapFrom(note => note.CreationDate));
        }
    }
}
