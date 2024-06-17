using FluentValidation;

namespace Backend.Application.Models.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryValidator 
        : AbstractValidator<GetUserDetailsQuery>
    {
        public GetUserDetailsQueryValidator() 
        {
            RuleFor(user => 
                user.UserId).NotEqual(string.Empty);
        }
    }
}
