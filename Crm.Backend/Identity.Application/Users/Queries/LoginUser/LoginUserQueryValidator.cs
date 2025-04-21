using FluentValidation;

namespace Identity.Application.Users.Queries.LoginUser
{
    public class LoginUserQueryValidator : AbstractValidator<LoginUserQuery>
    {
        public LoginUserQueryValidator()
        {
            RuleFor(loginUserQuery => loginUserQuery.Email)
                .NotEmpty().WithMessage("Email is required.")
                .MaximumLength(50).WithMessage("The maximum email length is 50 characters.");

            RuleFor(loginUserQuery => loginUserQuery.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
