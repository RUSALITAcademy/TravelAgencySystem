using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Domain.Models;
namespace Backend.Application.Models.Orders.Queries.GetOrderDetails
{
    public class OrderDetailsVm : IMapWith<Order>
    {
        public Guid OrderId { get; set; }
        public User User { get; set; }
        public Tour Tour { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDetailsVm>()
                .ForMember(clientVm => clientVm.OrderId,
                    opt => opt.MapFrom(client => client.OrderId))
                .ForMember(clientVm => clientVm.User,
                    opt => opt.MapFrom(client => client.User))
                .ForMember(clientVm => clientVm.Tour,
                    opt => opt.MapFrom(client => client.Tour))
                .ForMember(clientVm => clientVm.RegistrationDate,
                    opt => opt.MapFrom(client => client.RegistrationDate))
                .ForMember(clientVm => clientVm.Status,
                    opt => opt.MapFrom(client => client.Status));
        }
    }
}
