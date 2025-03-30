using Asp.Versioning;
using AutoMapper;
using Crm.Api.Models.DealModels;
using Crm.Application.Deals.Commands.CreateDeal;
using Crm.Application.Deals.Commands.DeleteDeal;
using Crm.Application.Deals.Commands.PatchDeal;
using Crm.Application.Deals.Commands.UpdateDeal;
using Crm.Application.Deals.Queries.GetDealDetails;
using Crm.Application.Deals.Queries.GetDealList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Api.Controllers.v1
{
    [ApiVersion(1, Deprecated = false)]
    [Produces("application/json")]
    [Route("api/v{version::apiVersion}/[controller]")]
    public class DealsController : BaseController
    {
        private readonly IMapper _mapper;

        public DealsController(IMapper mapper) =>
            _mapper = mapper;

        /// <summary>
        /// Gets the list of deals
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /deals?funnelId=6F9619FF-8B86-D011-B42D-00CF4FC964FF
        /// </remarks>
        /// <returns>Returns DealListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If unauthorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<DealListVm>> GetAll([FromQuery] GetDealListDto getDealListDto)
        {
            var query = new GetDealListQuery { };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Get the deal by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /deals/6F9619FF-8B86-D011-B42D-00CF4FC964FF
        /// </remarks>
        /// <param name="id">Deal id (guid)</param>
        /// <returns>Returns DealDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If unauthorized</response>
        /// <response code="404">If the deal not found</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<DealDetailsVm>> Get(Guid id)
        {
            var query = new GetDealDetailsQuery { Id = id };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Creates the deal
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /deals
        /// </remarks>
        /// <param name="createDealDto">CreateDealDto object</param>
        /// <returns>Returns id (guid) created deal</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If unauthorized</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(201)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateDealDto createDealDto)
        {
            var command = _mapper.Map<CreateDealCommand>(createDealDto);

            var dealId = await Mediator.Send(command);

            return CreatedAtAction(nameof(Create), dealId);
        }

        /// <summary>
        /// Updates the deal
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /deals
        /// {
        ///     ...
        /// }
        /// </remarks>
        /// <param name="updateDealDto">UpdateDealDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If unauthorized</response>
        /// <response code="404">If the deal not found</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update([FromBody] UpdateDealDto updateDealDto)
        {
            var command = _mapper.Map<UpdateDealCommand>(updateDealDto);

            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Patchs the deal
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PATCH /deals
        /// {
        ///     ...
        /// }
        /// </remarks>
        /// <param name="patchDealDto">PatchDealDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If unauthorized</response>
        /// <response code="404">If the deal not found</response>
        [HttpPatch]
        [Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Patch([FromBody] PatchDealDto patchDealDto)
        {
            var command = _mapper.Map<PatchDealCommand>(patchDealDto);

            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Deletes the deal
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /deals/6F9619FF-8B86-D011-B42D-00CF4FC964FF
        /// </remarks>
        /// <param name="id">Deal id (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If unauthorized</response>
        /// <response code="404">If the deal not found</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteDealCommand { Id = id };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
