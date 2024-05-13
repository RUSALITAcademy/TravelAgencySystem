using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Domain.Models;
using static Backend.Domain.Models.Order;
namespace Backend.Application.Models.Orders.Queries.GetOrderDetails
{
    public class OrderDetailsVm : IMapWith<Order>
    {
        public Guid OrderId { get; set; }
        public User User { get; set; }
        public Tour Tour { get; set; }
        public DateTime RegistrationStartDate { get; set; }
        public DateTime RegistrationEndDate { get; set; }
        public string NumberPhone { get; set; }
        public OrderStatus Status { get; set; }
        public bool HasChildren { get; set; }
        public int NumberOfPeople { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDetailsVm>()
                .ForMember(clientVm => clientVm.OrderId,
                    opt => opt.MapFrom(client => client.OrderId))
                .ForMember(clientVm => clientVm.User,
                    opt => opt.MapFrom(client => client.User))
                .ForMember(clientVm => clientVm.Tour,
                    opt => opt.MapFrom(client => client.Tour))
                .ForMember(clientVm => clientVm.RegistrationStartDate,
                    opt => opt.MapFrom(client => client.RegistrationStartDate))
                .ForMember(clientVm => clientVm.RegistrationEndDate,
                    opt => opt.MapFrom(client => client.RegistrationEndDate))
                .ForMember(clientVm => clientVm.NumberPhone,
                    opt => opt.MapFrom(client => client.NumberPhone))
                .ForMember(clientVm => clientVm.Status,
                    opt => opt.MapFrom(client => client.Status))
                .ForMember(clientVm => clientVm.HasChildren,
                        opt => opt.MapFrom(client => client.HasChildren))
                .ForMember(clientVm => clientVm.NumberOfPeople,
                    opt => opt.MapFrom(client => client.NumberOfPeople));
        }
    }
}
