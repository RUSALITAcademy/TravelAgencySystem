using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Models.Orders.Commands.CreateOrder;
using Backend.Domain.Models;
using static Backend.Domain.Models.Order;

namespace Backend.WebAPI.Models.CreateDto
{
    public class CreateOrderDto
        : IMapWith<CreateOrderCommand>
    {
        public string UserId { get; set; }
        public Guid TourId { get; set; }
        public DateTime RegistrationStartDate { get; set; }
        public DateTime RegistrationEndDate { get; set; }
        public string NumberPhone { get; set; }
        public OrderStatus Status { get; set; }
        public bool HasChildren { get; set; }
        public int NumberOfPeople { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderDto, CreateOrderCommand>()
                .ForMember(clientVm => clientVm.UserId,
                    opt => opt.MapFrom(client => client.UserId))
                .ForMember(clientVm => clientVm.TourId,
                    opt => opt.MapFrom(client => client.TourId))
                .ForMember(clientVm => clientVm.RegistrationStartDate,
                    opt => opt.MapFrom(client => client.RegistrationEndDate))
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
