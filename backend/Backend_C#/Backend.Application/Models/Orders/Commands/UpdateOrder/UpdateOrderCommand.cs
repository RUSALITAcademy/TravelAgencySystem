using Backend.Domain.Models;
using MediatR;

namespace Backend.Application.Models.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand
    : IRequest
    {
        public Guid OrderId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; }
    }
}
