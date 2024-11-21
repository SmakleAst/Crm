using FluentValidation;

namespace Crm.Application.Clients.Queries.GetClientDetails
{
    public class GetClientDetailsQueryValidator : AbstractValidator<GetClientDetailsQuery>
    {
        public GetClientDetailsQueryValidator()
        {
            RuleFor(getClientDetails => getClientDetails.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
