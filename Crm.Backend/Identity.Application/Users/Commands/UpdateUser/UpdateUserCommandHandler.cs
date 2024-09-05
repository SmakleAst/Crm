using Identity.Application.Common.Exceptions;
using Identity.Application.Interfaces;
using Identity.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IIdentityDbContext _dbContext;
        private readonly IPasswordHasher _passwordHasher;

        public UpdateUserCommandHandler(IIdentityDbContext dbContext, IPasswordHasher passwordHasher) =>
            (_dbContext, _passwordHasher) = (dbContext, passwordHasher);

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(entity => entity.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(User), request.Id);

            user.Email = request.Email;
            user.Password = _passwordHasher.Generate(request.Password);
            user.EditDate = DateTime.Now;

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
