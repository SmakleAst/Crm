using Crm.Application.Common.Exceptions;
using Crm.Application.Interfaces;
using Crm.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Application.Funnels.Commands.CreateFunnel
{
    public class CreateFunnelCommandHandler : IRequestHandler<CreateFunnelCommand, Guid>
    {
        private readonly ICrmDbContext _dbContext;

        public CreateFunnelCommandHandler(ICrmDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateFunnelCommand request, CancellationToken cancellationToken)
        {
            var funnel = await _dbContext.Funnels
                .FirstOrDefaultAsync(funnel => funnel.Name.ToLower().Equals(request.Name.ToLower()), cancellationToken);

            if (funnel != null)
            {
                throw new AlreadyExistsException(nameof(Funnel), request.Name);
            }

            funnel = new Funnel
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                CreationDate = DateTime.Now,
            };

            await _dbContext.Funnels.AddAsync(funnel, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return funnel.Id;
        }
    }
}
