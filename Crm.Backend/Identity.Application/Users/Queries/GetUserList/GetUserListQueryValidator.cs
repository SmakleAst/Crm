using FluentValidation;

namespace Identity.Application.Users.Queries.GetUserList
{
    public class GetUserListQueryValidator : AbstractValidator<GetUserListQuery>
    {
        public GetUserListQueryValidator() { }
    }
}
