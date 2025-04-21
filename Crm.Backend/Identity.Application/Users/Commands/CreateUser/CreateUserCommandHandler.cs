using Identity.Application.Common.Exceptions;
using Identity.Application.Interfaces;
using Identity.Domain.Entities;
using Identity.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler :  IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IIdentityDbContext _dbContext;
        private readonly IPasswordHasher _passwordHasher;

        public CreateUserCommandHandler(IIdentityDbContext dbContext, IPasswordHasher passwordHasher) =>
            (_dbContext, _passwordHasher) = (dbContext, passwordHasher);

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(entity => entity.Email.ToLower().Equals(request.Email.ToLower()), cancellationToken);

            if (user != null)
            {
                throw new AlreadyExistsException(nameof(User), request.Email);
            }

            user = new User
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                Password = _passwordHasher.Generate(request.Password),
                Role = Roles.Manager,
                CreationDate = DateTime.Now,
                EditDate = null
            };

            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
