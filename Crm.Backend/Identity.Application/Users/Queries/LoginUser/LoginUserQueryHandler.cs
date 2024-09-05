using Identity.Application.Interfaces;
using MediatR;

namespace Identity.Application.Users.Queries.LoginUser
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoginUserVm>
    {
        private readonly IIdentityDbContext _dbContext;
        private readonly IJwtToken _jwtToken;
        private readonly IPasswordHasher _passwordHasher;

        public LoginUserQueryHandler(IIdentityDbContext dbContext, IJwtToken jwtToken, IPasswordHasher passwordHasher) =>
            (_dbContext, _jwtToken, _passwordHasher) = (dbContext, jwtToken, passwordHasher);

        public async Task<LoginUserVm> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var 
        }
    }
}
