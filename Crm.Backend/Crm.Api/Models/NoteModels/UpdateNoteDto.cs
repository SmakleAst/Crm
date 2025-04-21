using AutoMapper;
using Crm.Application.Common.Mappings;
using Crm.Application.Notes.Commands.UpdateNote;

namespace Crm.Api.Models.NoteModels
{
    public class UpdateNoteDto : IMapWith<UpdateNoteCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public Guid ClientId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNoteDto, UpdateNoteCommand>()
                .ForMember(updateNoteCommand => updateNoteCommand.Id,
                    opt => opt.MapFrom(updateNoteDto => updateNoteDto.Id))
                .ForMember(updateNoteCommand => updateNoteCommand.Name,
                    opt => opt.MapFrom(updateNoteDto => updateNoteDto.Name))
                .ForMember(updateNoteCommand => updateNoteCommand.Details,
                    opt => opt.MapFrom(updateNoteDto => updateNoteDto.Details))
                .ForMember(updateNoteCommand => updateNoteCommand.ClientId,
                    opt => opt.MapFrom(updateNoteDto => updateNoteDto.ClientId));
        }
    }
}
