using MediatR;

namespace Identity.Application.Users.Queries.LoginUser
{
    public class LoginUserQuery : IRequest<LoginUserVm>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
