using FluentValidation;

namespace Crm.Application.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidator()
        {
            RuleFor(patchClientCommand => patchClientCommand.Id)
                .NotEmpty().WithMessage("Id is required.");

            RuleFor(patchClientCommand => patchClientCommand.ClientCode)
                .NotEmpty().WithMessage("Client code can't be empty or contain only whitespace.")
                .MaximumLength(50).WithMessage("Client code maximum length is 50 symbols.");

            RuleFor(patchClientCommand => patchClientCommand.LastName)
                .NotEmpty().WithMessage("Last name can't be empty or contain only whitespace.")
                .MaximumLength(50).WithMessage("Last name maximum length is 50 symbols.")
                .When(createCllientCommand => createCllientCommand.LastName != null);

            RuleFor(patchClientCommand => patchClientCommand.Name)
                .NotEmpty().WithMessage("Name can't be empty or contain only whitespace.")
                .MaximumLength(50).WithMessage("Name maximum length is 50 symbols.")
                .When(patchClientCommand => patchClientCommand.Name != null);

            RuleFor(patchClientCommand => patchClientCommand.MiddleName)
                .NotEmpty().WithMessage("Middle name can't be empty or contain only whitespace.")
                .MaximumLength(50).WithMessage("Middle name maximum length is 50 symbols.")
                .When(patchClientCommand => patchClientCommand.MiddleName != null);

            RuleFor(patchClientCommand => patchClientCommand.BirthDay)
                .LessThan(_ => DateTime.Now.AddYears(-18)).WithMessage("Client should be older than 18 years.")
                .GreaterThan(_ => DateTime.Now.AddYears(-120)).WithMessage("Client should be younger than 120 years.")
                .When(patchClientCommand => patchClientCommand.BirthDay != null);

            RuleFor(patchClientCommand => patchClientCommand.Email)
                .NotEmpty().WithMessage("Email can't be empty or contain only whitespace.")
                .MaximumLength(30).WithMessage("Email maximum length is 50 symbols.")
                .When(patchClientCommand => patchClientCommand.Email != null);

            RuleFor(patchClientCommand => patchClientCommand.Phone)
                .NotEmpty().WithMessage("Phone can't be empty or contain only whitespace.")
                .MaximumLength(11).WithMessage("Phone maximum length is 50 symbols.")
                .When(patchClientCommand => patchClientCommand.Phone != null);

            RuleFor(patchClientCommand => patchClientCommand.PostalCode)
                .NotEmpty().WithMessage("PostalCode can't be empty or contain only whitespace.")
                .MaximumLength(100).WithMessage("PostalCode maximum length is 50 symbols.")
                .When(patchClientCommand => patchClientCommand.PostalCode != null);

            RuleFor(patchClientCommand => patchClientCommand.City)
                .NotEmpty().WithMessage("City can't be empty or contain only whitespace.")
                .MaximumLength(20).WithMessage("City maximum length is 50 symbols.")
                .When(patchClientCommand => patchClientCommand.City != null);

            RuleFor(patchClientCommand => patchClientCommand.Country)
                .NotEmpty().WithMessage("Country can't be empty or contain only whitespace.")
                .MaximumLength(50).WithMessage("Country maximum length is 50 symbols.")
                .When(patchClientCommand => patchClientCommand.Country != null);
        }
    }
}
