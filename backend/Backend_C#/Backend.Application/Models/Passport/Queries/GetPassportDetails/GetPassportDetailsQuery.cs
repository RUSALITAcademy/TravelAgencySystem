using Backend.Application.Models.Orders.Queries.GetOrderDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Passport.Queries.GetPassportDetails
{
    public class GetPassportDetailsQuery : IRequest<PassportDetailsVm>
    {
        public Guid PassportId { get; set; }

    }
}
