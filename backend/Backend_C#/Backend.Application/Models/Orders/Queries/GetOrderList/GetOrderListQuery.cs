using AutoMapper;
using Backend.Application.Models.Orders.Commands.CreateOrder;
using Backend.Application.Models.Tours.Queries.GetTourList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Orders.Queries.GetOrderList
{
    public class GetOrderListQuery : IRequest<OrderListVm>
    {
        public string UserId { get; set; }
    }
}
