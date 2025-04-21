using FluentValidation;

namespace Identity.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(updateUserCommand => updateUserCommand.Email)
                .NotEmpty().WithMessage("Email is required.")
                .MaximumLength(50).WithMessage("The maximum email length is 50 characters.");

            RuleFor(updateUserCommand => updateUserCommand.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
