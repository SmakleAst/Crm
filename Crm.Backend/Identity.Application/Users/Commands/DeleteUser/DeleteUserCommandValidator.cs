using FluentValidation;

namespace Identity.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(deleteUserCommand => deleteUserCommand.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
