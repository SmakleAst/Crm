using Identity.Application.Common.Exceptions;
using Identity.Application.Interfaces;
using Identity.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IIdentityDbContext _dbContext;

        public DeleteUserCommandHandler(IIdentityDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(entity => entity.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(User), request.Id);

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
