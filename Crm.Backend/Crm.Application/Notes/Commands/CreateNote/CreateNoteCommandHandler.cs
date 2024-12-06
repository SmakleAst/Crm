using Crm.Application.Interfaces;
using Crm.Domain.Entities;
using MediatR;

namespace Crm.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly ICrmDbContext _dbContext;

        public CreateNoteCommandHandler(ICrmDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = new Note
            {
                Name = request.Name,
                Details = request.Details,
                ClientId = request.ClientId,
                CreationDate = DateTime.Now,
            };

            await _dbContext.Notes.AddAsync(note);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return note.Id;
        }
    }
}
