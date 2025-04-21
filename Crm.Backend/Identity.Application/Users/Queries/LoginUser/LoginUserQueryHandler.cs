using Identity.Application.Common.Exceptions;
using Identity.Application.Interfaces;
using Identity.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(entity => entity.Email.ToLower().Equals(request.Email.ToLower()), cancellationToken)
                ?? throw new NotFoundException(nameof(User), request.Email);

            if (!_passwordHasher.Verify(request.Password, user.Password))
            {
                throw new NotFoundException(nameof(User), request.Password);
            }

            return new LoginUserVm { Token = _jwtToken.Generate(user) };
        }
    }
}
