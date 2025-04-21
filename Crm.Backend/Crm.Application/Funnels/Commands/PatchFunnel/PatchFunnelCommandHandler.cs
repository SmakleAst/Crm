using Crm.Application.Common.Exceptions;
using Crm.Application.Interfaces;
using Crm.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Application.Funnels.Commands.PatchFunnel
{
    public class PatchFunnelCommandHandler : IRequestHandler<PatchFunnelCommand, Unit>
    {
        private readonly ICrmDbContext _dbContext;

        public PatchFunnelCommandHandler(ICrmDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(PatchFunnelCommand request, CancellationToken cancellationToken)
        {
            var funnel = await _dbContext.Funnels
                .FirstOrDefaultAsync(funnel => funnel.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Funnel), request.Id);

            funnel.Name = request.Name ?? funnel.Name;
            funnel.EditDate = DateTime.Now;

            _dbContext.Funnels.Update(funnel);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
