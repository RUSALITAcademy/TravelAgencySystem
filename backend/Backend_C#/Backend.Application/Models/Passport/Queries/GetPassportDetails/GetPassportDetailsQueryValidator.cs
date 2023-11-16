using FluentValidation;

namespace Backend.Application.Models.Passport.Queries.GetPassportDetails
{
    public class GetPassportDetailsQueryValidator : AbstractValidator<GetPassportDetailsQuery>
    {
        public GetPassportDetailsQueryValidator()
        {
            RuleFor(user =>
                user.PassportId).NotEqual(Guid.Empty);
        }
    }
}
