using Backend.Application.Models.Passport.Queries.GetPassportDetails;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.InternationalPassport.Queries.GetInternationalPassportDetails
{
    public class GetInternationalPassportDetailsQueryValidator : AbstractValidator<GetInternationalPassportDetailsQuery>
    {
        public GetInternationalPassportDetailsQueryValidator()
        {
            RuleFor(user =>
                user.InternationalPassportId).NotEqual(Guid.Empty);
        }
    }
}
