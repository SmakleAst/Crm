using Asp.Versioning;
using AutoMapper;
using Identity.Api.Models;
using Identity.Application.Users.Commands.CreateUser;
using Identity.Application.Users.Commands.DeleteUser;
using Identity.Application.Users.Commands.PatchUser;
using Identity.Application.Users.Commands.UpdateUser;
using Identity.Application.Users.Queries.GetUserDetails;
using Identity.Application.Users.Queries.GetUserList;
using Identity.Application.Users.Queries.LoginUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers.v1
{
    [ApiVersion(1, Deprecated = false)]
    [Produces("application/json")]
    [Route("api/v{version::apiVersion}/[controller]")]
    public class UsersController : BaseController
    {
        private readonly IMapper _mapper;

        public UsersController(IMapper mapper) =>
            _mapper = mapper;

        /// <summary>
        /// Gets the list of users
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /users
        /// </remarks>
        /// <returns>Returns UserListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If unauthorize</response>
        [HttpGet]
        [Authorize(Roles = "0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserListVm>> GetAll()
        {
            var query = new GetUserListQuery() { };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Gets the user by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /users/6F9619FF-8B86-D011-B42D-00CF4FC964FF
        /// </remarks>
        /// <param name="id">User id (guid)</param>
        /// <returns>Returns UserDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If unauthorized</response>
        /// <response code="404">If the user not found</response>
        [HttpGet("{id}")]
        [Authorize(Roles = "0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDetailsVm>> Get(Guid id)
        {
            var query = new GetUserDetailsQuery() { Id = id };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }


        /// <summary>
        /// Creates the user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /users
        /// {
        ///     Email: "test@mail.ru",
        ///     Password: "testpassword"
        /// }
        /// </remarks>
        /// <param name="createUserDto">CreateUserDto object</param>
        /// <returns>Returns id (guid) created user</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If unauthorized</response>
        /// <response code="409">If the user with same email already exists</response>
        [HttpPost]
        [Authorize(Roles = "0")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserDto createUserDto)
        {
            var command = _mapper.Map<CreateUserCommand>(createUserDto);

            var userId = await Mediator.Send(command);

            return CreatedAtAction(nameof(Create), userId);
        }


        /// <summary>
        /// Updates the user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /users
        /// {
        ///     Id: 6F9619FF-8B86-D011-B42D-00CF4FC964FF,
        ///     Email: test@mail.ru,
        ///     Password: "testpassword"
        /// }
        /// </remarks>
        /// <param name="updateUserDto">UpdateuserDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If unauthorized</response>
        /// <response code="404">If the user with same id not found</response>
        [HttpPut]
        [Authorize(Roles = "0")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto updateUserDto)
        {
            var command = _mapper.Map<UpdateUserCommand>(updateUserDto);

            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Patchs the user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PATCH /users
        /// {
        ///     Id: 6F9619FF-8B86-D011-B42D-00CF4FC964FF,
        ///     Email: test@mail.ru
        /// }
        /// </remarks>
        /// <param name="patchUserDto">PatchUserDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If unauthorized</response>
        /// <response code="404">If the user with same id not found</response>
        [HttpPatch]
        [Authorize(Roles = "0")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Patch([FromBody] PatchUserDto patchUserDto)
        {
            var command = _mapper.Map<PatchUserCommand>(patchUserDto);

            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Deletes the user by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /users/6F9619FF-8B86-D011-B42D-00CF4FC964FF
        /// </remarks>
        /// <param name="id">User id (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If unauthorized</response>
        /// <response code="404">If the user with same id not found</response>
        [HttpDelete("{id}")]
        [Authorize(Roles = "0")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand { Id = id };

            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Logins the user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /users/login
        /// {
        ///     Email: "test@mail.ru",
        ///     Password: "testpassword"  
        /// }
        /// </remarks>
        /// <param name="loginUserDto">LoginUserDto object</param>
        /// <returns>Returns LoginUserVm</returns>
        /// <response code="200">Success</response>
        /// <response code="404">If the user with same email and password not found</response>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LoginUserVm>> Login([FromBody] LoginUserDto loginUserDto)
        {
            var query = _mapper.Map<LoginUserQuery>(loginUserDto);

            var vm = await Mediator.Send(query);

            return Ok();
        }
    }
}
