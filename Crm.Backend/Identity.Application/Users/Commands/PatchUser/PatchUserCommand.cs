using MediatR;

namespace Identity.Application.Users.Commands.PatchUser
{
    public class PatchUserCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
