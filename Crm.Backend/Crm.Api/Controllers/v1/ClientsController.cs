using Asp.Versioning;
using AutoMapper;
using Crm.Api.Models.ClientModels;
using Crm.Application.Clients.Commands.CreateClient;
using Crm.Application.Clients.Commands.DeleteClient;
using Crm.Application.Clients.Commands.PatchClient;
using Crm.Application.Clients.Commands.UpdateClient;
using Crm.Application.Clients.Queries.GetClientDetails;
using Crm.Application.Clients.Queries.GetClientList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Api.Controllers.v1
{
    [ApiVersion(1, Deprecated = false)]
    [Produces("application/json")]
    [Route("api/v{version::apiVersion}/[controller]")]
    public class ClientsController : BaseController
    {
        private readonly IMapper _mapper;

        public ClientsController(IMapper mapper) =>
            _mapper = mapper;

        /// <summary>
        /// Gets the list of clients
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /clients
        /// </remarks>
        /// <returns>Returns CleintListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If unauthorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<ClientListVm>> GetAll()
        {
            var query = new GetClientListQuery { };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Gets the client by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /clients/6F9619FF-8B86-D011-B42D-00CF4FC964FF
        /// </remarks>
        /// <param name="id">Client id (guid)</param>
        /// <returns>Returns ClientDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If unauthorized</response>
        /// <response code="404">If the client not found</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ClientDetailsVm>> Get(Guid id)
        {
            var query = new GetClientDetailsQuery { Id = id };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Creates the client
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /clients
        /// {
        ///     ...
        /// }
        /// </remarks>
        /// <param name="createClientDto">CreateClientDto object</param>
        /// <returns>Returns id (guid) created client</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If unauthorized</response>
        /// <response code="409"></response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(201)]
        [ProducesResponseType(401)]
        [ProducesResponseType(409)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateClientDto createClientDto)
        {
            var command = _mapper.Map<CreateClientCommand>(createClientDto);

            var clientId = await Mediator.Send(command);

            return CreatedAtAction(nameof(Create), clientId);
        }

        /// <summary>
        /// Updates the client
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /clients
        /// {
        ///     ...
        /// }
        /// </remarks>
        /// <param name="updateClientDto">UpdateClientDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If unauthorized</response>
        /// <response code="404">If the client not found</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update([FromBody] UpdateClientDto updateClientDto)
        {
            var command = _mapper.Map<UpdateClientCommand>(updateClientDto);

            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Patchs the client
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PATCH /clients
        /// {
        ///     ...
        /// }
        /// </remarks>
        /// <param name="patchClientDto">PatchClientDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If unauthorized</response>
        /// <response code="404">If the client not found</response>
        [HttpPatch]
        [Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Patch([FromBody] PatchClientDto patchClientDto)
        {
            var command = _mapper.Map<PatchClientCommand>(patchClientDto);

            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Deletes the client
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /clients/6F9619FF-8B86-D011-B42D-00CF4FC964FF
        /// </remarks>
        /// <param name="id">Client id (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If unauthorized</response>
        /// <response code="404">If the client not found</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteClientCommand { Id = id };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
