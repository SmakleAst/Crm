using FluentValidation;

namespace Crm.Application.Clients.Commands.DeleteClient
{
    public class DeleteClientCommandValidator : AbstractValidator<DeleteClientCommand>
    {
        public DeleteClientCommandValidator()
        {
            RuleFor(deleteClientCommand => deleteClientCommand.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
