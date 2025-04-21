using Asp.Versioning;
using AutoMapper;
using Crm.Api.Models.NoteModels;
using Crm.Application.Notes.Commands.CreateNote;
using Crm.Application.Notes.Commands.DeleteNote;
using Crm.Application.Notes.Commands.PatchNote;
using Crm.Application.Notes.Commands.UpdateNote;
using Crm.Application.Notes.Queries.GetNoteDetails;
using Crm.Application.Notes.Queries.GetNoteList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Api.Controllers.v1
{
    [ApiVersion(1, Deprecated = false)]
    [Produces("application/json")]
    [Route("api/v{version::apiVersion}/[controller]")]
    public class NotesController : BaseController
    {
        private readonly IMapper _mapper;

        public NotesController(IMapper mapper) =>
            _mapper = mapper;

        /// <summary>
        /// Gets the list of notes
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /notes?clientId=6F9619FF-8B86-D011-B42D-00CF4FC964FF
        /// </remarks>
        /// <param name="getNoteListDto">GetNoteListDto object</param>
        /// <returns>Return NoteListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If unauthorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<NoteListVm>> GetAll([FromQuery] GetNoteListDto getNoteListDto)
        {
            var query = _mapper.Map<GetNoteListQuery>(getNoteListDto);

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Gets the note by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /notes/6F9619FF-8B86-D011-B42D-00CF4FC964FF
        /// </remarks>
        /// <param name="id">Note id (guid)</param>
        /// <returns>Returns NoteDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If unauthorized</response>
        /// <response code="404">If the note not found</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<NoteDetailsVm>> Get(Guid id)
        {
            var query = new GetNoteDetailsQuery { Id = id };

            var vm = await Mediator.Send(query);
            
            return Ok(vm);
        }

        /// <summary>
        /// Creates the note
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /notes
        /// {
        ///     ...
        /// }
        /// </remarks>
        /// <param name="createNoteDto">CreateNoteDto object</param>
        /// <returns>Returns id (guid) created note</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If unauthorized</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteDto createNoteDto)
        {
            var command = _mapper.Map<CreateNoteCommand>(createNoteDto);

            var noteId = await Mediator.Send(command);

            return CreatedAtAction(nameof(Create), noteId);
        }

        /// <summary>
        /// Updates the note
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /notes
        /// {
        ///     ...
        /// }
        /// </remarks>
        /// <param name="updateNoteDto">UpdateNoteDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If unauthorized</response>
        /// <response code="404">If the note not found</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update([FromBody] UpdateNoteDto updateNoteDto)
        {
            var command = _mapper.Map<UpdateNoteCommand>(updateNoteDto);

            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Patchs the note
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PATCH /notes
        /// {
        ///     ...
        /// }
        /// </remarks>
        /// <param name="patchNoteDto">PatchNoteDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If unauthorized</response>
        /// <response code="404">If the note not found</response>
        [HttpPatch]
        [Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Patch([FromBody] PatchNoteDto patchNoteDto)
        {
            var command = _mapper.Map<PatchNoteCommand>(patchNoteDto);

            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Deletes the note
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /notes/6F9619FF-8B86-D011-B42D-00CF4FC964FF
        /// </remarks>
        /// <param name="id">Note id (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If unauthorized</response>
        /// <response code="404">If the note not found</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteNoteCommand { Id = id };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
