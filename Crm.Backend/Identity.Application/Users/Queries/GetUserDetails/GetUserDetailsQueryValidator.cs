using FluentValidation;

namespace Identity.Application.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryValidator : AbstractValidator<GetUserDetailsQuery>
    {
        public GetUserDetailsQueryValidator()
        {
            RuleFor(getUserDetailsQuery => getUserDetailsQuery.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
