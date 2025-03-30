using AutoMapper;
using Crm.Application.Common.Mappings;
using Crm.Application.Notes.Commands.PatchNote;

namespace Crm.Api.Models.NoteModels
{
    public class PatchNoteDto : IMapWith<PatchNoteCommand>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Details { get; set; }
        public Guid? ClientId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PatchNoteDto, PatchNoteCommand>()
                .ForMember(patchNoteCommand => patchNoteCommand.Id,
                    opt => opt.MapFrom(patchNoteDto => patchNoteDto.Id))
                .ForMember(patchNoteCommand => patchNoteCommand.Name,
                    opt => opt.MapFrom(patchNoteDto => patchNoteDto.Name))
                .ForMember(patchNoteCommand => patchNoteCommand.Details,
                    opt => opt.MapFrom(patchNoteDto => patchNoteDto.Details))
                .ForMember(patchNoteCommand => patchNoteCommand.ClientId,
                    opt => opt.MapFrom(patchNoteDto => patchNoteDto.ClientId));
        }
    }
}
