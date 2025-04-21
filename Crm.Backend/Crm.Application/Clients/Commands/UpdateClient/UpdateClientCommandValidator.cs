using FluentValidation;

namespace Crm.Application.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidator()
        {
            RuleFor(updateClientCommand => updateClientCommand.Id)
                .NotEmpty().WithMessage("Id is required.");

            RuleFor(updateClientCommand => updateClientCommand.ClientCode)
                .NotEmpty().WithMessage("Client code can't be empty or contain only whitespace.")
                .MaximumLength(50).WithMessage("Client code maximum length is 50 symbols.");

            RuleFor(updateClientCommand => updateClientCommand.LastName)
                .NotEmpty().WithMessage("Last name can't be empty or contain only whitespace.")
                .MaximumLength(50).WithMessage("Last name maximum length is 50 symbols.")
                .When(createCllientCommand => createCllientCommand.LastName != null);

            RuleFor(updateClientCommand => updateClientCommand.Name)
                .NotEmpty().WithMessage("Name can't be empty or contain only whitespace.")
                .MaximumLength(50).WithMessage("Name maximum length is 50 symbols.")
                .When(updateClientCommand => updateClientCommand.Name != null);

            RuleFor(updateClientCommand => updateClientCommand.MiddleName)
                .NotEmpty().WithMessage("Middle name can't be empty or contain only whitespace.")
                .MaximumLength(50).WithMessage("Middle name maximum length is 50 symbols.")
                .When(updateClientCommand => updateClientCommand.MiddleName != null);

            RuleFor(updateClientCommand => updateClientCommand.BirthDay)
                .LessThan(_ => DateTime.Now.AddYears(-18)).WithMessage("Client should be older than 18 years.")
                .GreaterThan(_ => DateTime.Now.AddYears(-120)).WithMessage("Client should be younger than 120 years.")
                .When(updateClientCommand => updateClientCommand.BirthDay != null);

            RuleFor(updateClientCommand => updateClientCommand.Email)
                .NotEmpty().WithMessage("Email can't be empty or contain only whitespace.")
                .MaximumLength(30).WithMessage("Email maximum length is 50 symbols.")
                .When(updateClientCommand => updateClientCommand.Email != null);

            RuleFor(updateClientCommand => updateClientCommand.Phone)
                .NotEmpty().WithMessage("Phone can't be empty or contain only whitespace.")
                .MaximumLength(11).WithMessage("Phone maximum length is 50 symbols.")
                .When(updateClientCommand => updateClientCommand.Phone != null);

            RuleFor(updateClientCommand => updateClientCommand.PostalCode)
                .NotEmpty().WithMessage("PostalCode can't be empty or contain only whitespace.")
                .MaximumLength(100).WithMessage("PostalCode maximum length is 50 symbols.")
                .When(updateClientCommand => updateClientCommand.PostalCode != null);

            RuleFor(updateClientCommand => updateClientCommand.City)
                .NotEmpty().WithMessage("City can't be empty or contain only whitespace.")
                .MaximumLength(20).WithMessage("City maximum length is 50 symbols.")
                .When(updateClientCommand => updateClientCommand.City != null);

            RuleFor(updateClientCommand => updateClientCommand.Country)
                .NotEmpty().WithMessage("Country can't be empty or contain only whitespace.")
                .MaximumLength(50).WithMessage("Country maximum length is 50 symbols.")
                .When(updateClientCommand => updateClientCommand.Country != null);
        }
    }
}
