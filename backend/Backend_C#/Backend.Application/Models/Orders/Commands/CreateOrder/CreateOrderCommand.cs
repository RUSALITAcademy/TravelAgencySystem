using Backend.Domain.Models;
using MediatR;
using static Backend.Domain.Models.Order;
namespace Backend.Application.Models.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand :
        IRequest<Guid>
    {
        public string UserId { get; set; }
        public Guid TourId { get; set; }
        public DateTime RegistrationStartDate { get; set; }
        public DateTime RegistrationEndDate { get; set; }
        public string NumberPhone { get; set; }
        public OrderStatus Status { get; set; }
        public bool IsChild { get; set; }
        public int NumberOfPeople { get; set; }
    }
}
