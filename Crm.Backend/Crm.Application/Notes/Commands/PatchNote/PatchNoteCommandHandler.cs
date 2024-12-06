using Crm.Application.Common.Exceptions;
using Crm.Application.Interfaces;
using Crm.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Crm.Application.Notes.Commands.PatchNote
{
    public class PatchNoteCommandHandler : IRequestHandler<PatchNoteCommand, Unit>
    {
        private readonly ICrmDbContext _dbContext;

        public PatchNoteCommandHandler(ICrmDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(PatchNoteCommand request, CancellationToken cancellationToken)
        {
            var note = await _dbContext.Notes
                .FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Note), request.Id);

            note.Name = request.Name ?? note.Name;
            note.Details = request.Details ?? note.Details;
            note.ClientId = request.ClientId ?? note.ClientId;
            note.EditDate = DateTime.Now;

            _dbContext.Notes.Update(note);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
