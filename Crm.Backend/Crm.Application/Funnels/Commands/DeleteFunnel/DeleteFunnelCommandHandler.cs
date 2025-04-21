using Crm.Application.Common.Exceptions;
using Crm.Application.Interfaces;
using Crm.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Application.Funnels.Commands.DeleteFunnel
{
    public class DeleteFunnelCommandHandler : IRequestHandler<DeleteFunnelCommand, Unit>
    {
        private readonly ICrmDbContext _dbContext;

        public DeleteFunnelCommandHandler(ICrmDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteFunnelCommand request, CancellationToken cancellationToken)
        {
            var funnel = await _dbContext.Funnels
                .FirstOrDefaultAsync(funnel => funnel.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Funnel), request.Id);

            _dbContext.Funnels.Remove(funnel);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
