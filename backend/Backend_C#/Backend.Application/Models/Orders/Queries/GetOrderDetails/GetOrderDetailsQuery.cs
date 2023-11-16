using Backend.Application.Models.Users.Queries.GetUserDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQuery
    : IRequest<OrderDetailsVm>
    {
        public Guid OrderId { get; set; }

    }
}
