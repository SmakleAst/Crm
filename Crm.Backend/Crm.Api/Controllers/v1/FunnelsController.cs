using Asp.Versioning;
using AutoMapper;
using Crm.Api.Models.FunnelModels;
using Crm.Application.Funnels.Commands.CreateFunnel;
using Crm.Application.Funnels.Commands.DeleteFunnel;
using Crm.Application.Funnels.Commands.PatchFunnel;
using Crm.Application.Funnels.Queries.GetFunnelDetails;
using Crm.Application.Funnels.Queries.GetFunnelList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Api.Controllers.v1
{
    [ApiVersion(1, Deprecated = false)]
    [Produces("application/json")]
    [Route("api/v{version::apiVersion}/[controller]")]
    public class FunnelsController : BaseController
    {
        private readonly IMapper _mapper;

        public FunnelsController(IMapper mapper) =>
            _mapper = mapper;

        /// <summary>
        /// Gets the list of funnels
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /funnels
        /// </remarks>
        /// <returns>Returns FunnelListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If unauthorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<FunnelListVm>> GetAll()
        {
            var query = new GetFunnelListQuery { };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Get the funnel by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /funnels/6F9619FF-8B86-D011-B42D-00CF4FC964FF
        /// </remarks>
        /// <param name="id">Funnel id (guid)</param>
        /// <returns>Returns FunnelDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If unauthorized</response>
        /// <response code="404">If the funnel not found</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<FunnelDetailsVm>> Get(Guid id)
        {
            var query = new GetFunnelDetailsQuery { Id = id };

            var vm = await Mediator.Send(query);
            
            return Ok(vm);
        }

        /// <summary>
        /// Creates the funnel
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /funnels
        /// {
        ///     ...
        /// }
        /// </remarks>
        /// <param name="createFunnelDto">CreateFunnelDto object</param>
        /// <returns>Returns if (guid) created funnel</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If unauthorized</response>
        /// <response code="404">If the funnel not found</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(201)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateFunnelDto createFunnelDto)
        {
            var command = _mapper.Map<CreateFunnelCommand>(createFunnelDto);

            var funnelId = await Mediator.Send(command);

            return CreatedAtAction(nameof(Create), funnelId);
        }

        /// <summary>
        /// Patchs the funnel
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PATCH /funnels
        /// {
        ///     ...
        /// }
        /// </remarks>
        /// <param name="patchFunnelDto">PatchFunnelDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If unauthorized</response>
        /// <response code="404">If the funnel not found</response>
        [HttpPatch]
        [Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Patch([FromBody] PatchFunnelDto patchFunnelDto)
        {
            var command = _mapper.Map<PatchFunnelCommand>(patchFunnelDto);

            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Deletes the funnel
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /funnels/6F9619FF-8B86-D011-B42D-00CF4FC964FF
        /// </remarks>
        /// <param name="id">Funnel id (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If unauthorized</response>
        /// <response code="404">If the funnel not found</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteFunnelCommand { Id = id };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
