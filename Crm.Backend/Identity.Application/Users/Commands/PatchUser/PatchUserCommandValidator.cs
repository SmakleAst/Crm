using FluentValidation;

namespace Identity.Application.Users.Commands.PatchUser
{
    public class PatchUserCommandValidator : AbstractValidator<PatchUserCommand>
    {
        public PatchUserCommandValidator()
        {
            RuleFor(patchUserCommand => patchUserCommand.Email)
                .MaximumLength(50)
                .When(patchUserCommand => !string.IsNullOrEmpty(patchUserCommand.Email)).WithMessage("The maximum email length is 50 characters.")
                .NotEqual("").WithMessage("Email cant be empty.");
        }
    }
}
