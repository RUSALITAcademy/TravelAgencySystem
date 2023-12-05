using Backend.Application.Models.Users.Queries.GetUserDetails;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryValidator
    : AbstractValidator<GetOrderDetailsQuery>
    {
        public GetOrderDetailsQueryValidator()
        {
            RuleFor(user =>
                user.OrderId).NotEqual(Guid.Empty);
        }
    }
}
