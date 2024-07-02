using MediatR;

namespace Backend.Application.Models.Orders.Queries.GetOrderList
{
    public class GetOrderListQuery : IRequest<OrderListVm>
    {
        public string UserId { get; set; }
        public Guid? TourId { get; set; }
        public bool IsTourAgent { get; set; }
    }
}
