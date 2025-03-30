using AutoMapper;
using Crm.Application.Common.Mappings;
using Crm.Application.Notes.Commands.CreateNote;

namespace Crm.Api.Models.NoteModels
{
    public class CreateNoteDto : IMapWith<CreateNoteCommand>
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public Guid ClientId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNoteDto, CreateNoteCommand>()
                .ForMember(createNoteCommand => createNoteCommand.Name,
                    opt => opt.MapFrom(createNoteDto => createNoteDto.Name))
                .ForMember(createNoteCommand => createNoteCommand.Details,
                    opt => opt.MapFrom(createNoteDto => createNoteDto.Details))
                .ForMember(createNoteCommand => createNoteCommand.ClientId,
                    opt => opt.MapFrom(createNoteDto => createNoteDto.ClientId));
        }
    }
}
