using AutoMapper;
using Crm.Application.Common.Mappings;
using Crm.Application.Notes.Queries.GetNoteList;

namespace Crm.Api.Models.NoteModels
{
    public class GetNoteListDto : IMapWith<GetNoteListQuery>
    {
        public Guid? ClientId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetNoteListDto, GetNoteListQuery>()
                .ForMember(getNoteListCommand => getNoteListCommand.ClientId,
                    opt => opt.MapFrom(getNoteListDto => getNoteListDto.ClientId));
        }
    }
}
