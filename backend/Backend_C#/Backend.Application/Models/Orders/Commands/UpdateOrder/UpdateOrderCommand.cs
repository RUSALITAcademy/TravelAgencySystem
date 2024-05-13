using Backend.Domain.Models;
using MediatR;
using static Backend.Domain.Models.Order;

namespace Backend.Application.Models.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand
    : IRequest
    {
        public Guid OrderId { get; set; }
        public DateTime RegistrationStartDate { get; set; }
        public DateTime RegistrationEndDate { get; set; }
        public OrderStatus Status { get; set; }
    }
}
