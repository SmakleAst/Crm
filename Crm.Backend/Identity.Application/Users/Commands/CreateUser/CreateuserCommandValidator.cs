using FluentValidation;

namespace Identity.Application.Users.Commands.CreateUser
{
    public class CreateuserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateuserCommandValidator()
        {
            RuleFor(createUserCommand => createUserCommand.Email)
                .NotEmpty().WithMessage("Email is required.")
                .MaximumLength(50).WithMessage("The maximum email length is 50 characters.");

            RuleFor(createUserCommand => createUserCommand.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
