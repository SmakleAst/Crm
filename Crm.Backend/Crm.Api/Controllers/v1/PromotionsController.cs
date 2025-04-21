using Asp.Versioning;
using AutoMapper;
using Crm.Api.Models.PromotionModels;
using Crm.Application.Promotions.Commands.CreatePromotion;
using Crm.Application.Promotions.Commands.DeletePromotion;
using Crm.Application.Promotions.Commands.PatchPromotion;
using Crm.Application.Promotions.Queries.GetPromotionDetails;
using Crm.Application.Promotions.Queries.GetPromotionList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Api.Controllers.v1;

[ApiVersion(1, Deprecated = false)]
[Produces("application/json")]
[Route("api/v{version::apiVersion}/[controller]")]
public class PromotionsController : BaseController
{
    private readonly IMapper _mapper;
    
    public PromotionsController(IMapper mapper) =>
        _mapper = mapper;

    /// <summary>
    /// Gets the list of promotions
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /promotions
    /// </remarks>
    /// <returns>Returns PromotionListVm</returns>
    /// <response code="200">Success</response>
    /// <response code="401">If unauthorized</response>
    [HttpGet]
    [Authorize]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<PromotionListVm>> GetAll()
    {
        var query = new GetPromotionListQuery { };
        
        var vm = await Mediator.Send(query);
        
        return Ok(vm);
    }

    /// <summary>
    /// Gets the promotion by id
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /promotions/6F9619FF-8B86-D011-B42D-00CF4FC964FF
    /// </remarks>
    /// <param name="id">Promotion id (guid)</param>
    /// <returns>Returns PromotionDetailsVm</returns>
    /// <response code="200">Success</response>
    /// <response code="401">If unauthorized</response>
    /// <response code="404">If the promotion not found</response>
    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<PromotionDetailsVm>> Get(Guid id)
    {
        var query = new GetPromotionDetailsQuery { Id = id };
        
        var vm = await Mediator.Send(query);
        
        return Ok(vm);
    }

    /// <summary>
    /// Creates the promotion
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// POST /promotions
    /// {
    ///     ...
    /// }
    /// </remarks>
    /// <param name="createPromotionDto">CreatePromotionDto object</param>
    /// <returns>Returns id (guid) created promotion</returns>
    /// <response code="201">Success</response>
    /// <response code="401">If unauthorized</response>
    /// <response code="409"></response>
    [HttpPost]
    [Authorize]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(409)]
    public async Task<ActionResult<Guid>> Create([FromBody] CreatePromotionDto createPromotionDto)
    {
        var command = _mapper.Map<CreatePromotionCommand>(createPromotionDto);
        
        var promotionId = await Mediator.Send(command);
        
        return CreatedAtAction(nameof(Create), promotionId);
    }

    /// <summary>
    /// Patchs the promotion
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// PATCH /promotions
    /// {
    ///     ...
    /// }
    /// </remarks>
    /// <param name="patchPromotionDto">PatchPromotionDto object</param>
    /// <returns>Returns NoContent</returns>
    /// <response code="204">Success</response>
    /// <response code="401">If unauthorized</response>
    /// <response code="404">If the promotion not found</response>
    [HttpPatch]
    [Authorize]
    [ProducesResponseType(204)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Patch([FromBody] PatchPromotionDto patchPromotionDto)
    {
        var command = _mapper.Map<PatchPromotionCommand>(patchPromotionDto);
        
        await Mediator.Send(command);
        
        return NoContent();
    }

    /// <summary>
    /// Deletes the promotions
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// DELETE /promotions/6F9619FF-8B86-D011-B42D-00CF4FC964FF
    /// </remarks>
    /// <param name="id">Promotion id (guid)</param>
    /// <returns>Returns NoContent</returns>
    /// <response code="204">Success</response>
    /// <response code="401">If unauthorized</response>
    /// <response code="404">If the promotion not found</response>
    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(204)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeletePromotionCommand { Id = id };
        
        await Mediator.Send(command);
        
        return NoContent();
    }
}