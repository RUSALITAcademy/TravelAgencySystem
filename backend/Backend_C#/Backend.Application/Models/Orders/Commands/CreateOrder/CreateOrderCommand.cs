using Backend.Domain.Models;
using MediatR;
namespace Backend.Application.Models.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand :
        IRequest<Guid>
    {
        public string UserId { get; set; }
        public Guid TourId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; }
    }
}
