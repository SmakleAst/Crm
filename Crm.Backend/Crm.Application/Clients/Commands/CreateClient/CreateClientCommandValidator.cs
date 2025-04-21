using FluentValidation;

namespace Crm.Application.Clients.Commands.CreateClient
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(createClientCommand => createClientCommand.ClientCode)
                .NotEmpty().WithMessage("Client code can't be empty or contain only whitespace.")
                .MaximumLength(50).WithMessage("Client code maximum length is 50 symbols.");

            RuleFor(createClientCommand => createClientCommand.LastName)
                .NotEmpty().WithMessage("Last name can't be empty or contain only whitespace.")
                .MaximumLength(50).WithMessage("Last name maximum length is 50 symbols.")
                .When(createCllientCommand => createCllientCommand.LastName != null);

            RuleFor(createClientCommand => createClientCommand.Name)
                .NotEmpty().WithMessage("Name can't be empty or contain only whitespace.")
                .MaximumLength(50).WithMessage("Name maximum length is 50 symbols.")
                .When(createClientCommand => createClientCommand.Name != null);

            RuleFor(createClientCommand => createClientCommand.MiddleName)
                .NotEmpty().WithMessage("Middle name can't be empty or contain only whitespace.")
                .MaximumLength(50).WithMessage("Middle name maximum length is 50 symbols.")
                .When(createClientCommand => createClientCommand.MiddleName != null);

            RuleFor(createClientCommand => createClientCommand.BirthDay)
                .LessThan(_ => DateTime.Now.AddYears(-18)).WithMessage("Client should be older than 18 years.")
                .GreaterThan(_ => DateTime.Now.AddYears(-120)).WithMessage("Client should be younger than 120 years.")
                .When(createClientCommand => createClientCommand.BirthDay != null);

            RuleFor(createClientCommand => createClientCommand.Email)
                .NotEmpty().WithMessage("Email can't be empty or contain only whitespace.")
                .MaximumLength(30).WithMessage("Email maximum length is 50 symbols.")
                .When(createClientCommand => createClientCommand.Email != null);

            RuleFor(createClientCommand => createClientCommand.Phone)
                .NotEmpty().WithMessage("Phone can't be empty or contain only whitespace.")
                .MaximumLength(11).WithMessage("Phone maximum length is 50 symbols.")
                .When(createClientCommand => createClientCommand.Phone != null);

            RuleFor(createClientCommand => createClientCommand.PostalCode)
                .NotEmpty().WithMessage("PostalCode can't be empty or contain only whitespace.")
                .MaximumLength(100).WithMessage("PostalCode maximum length is 50 symbols.")
                .When(createClientCommand => createClientCommand.PostalCode != null);

            RuleFor(createClientCommand => createClientCommand.City)
                .NotEmpty().WithMessage("City can't be empty or contain only whitespace.")
                .MaximumLength(20).WithMessage("City maximum length is 50 symbols.")
                .When(createClientCommand => createClientCommand.City != null);

            RuleFor(createClientCommand => createClientCommand.Country)
                .NotEmpty().WithMessage("Country can't be empty or contain only whitespace.")
                .MaximumLength(50).WithMessage("Country maximum length is 50 symbols.")
                .When(createClientCommand => createClientCommand.Country != null);
        }
    }
}
