using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Models.Orders.Commands.UpdateOrder;
using Backend.Domain.Models;
using static Backend.Domain.Models.Order;

namespace Backend.WebAPI.Models.UpdateDto
{
    public class UpdateOrderDto
    : IMapWith<UpdateOrderCommand>
    {
        public DateTime RegistrationStartDate { get; set; }
        public DateTime RegistrationEndDate { get; set; }
        public OrderStatus Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateOrderDto, UpdateOrderCommand>()
                .ForMember(clientVm => clientVm.RegistrationStartDate,
                    opt => opt.MapFrom(client => client.RegistrationStartDate))
                .ForMember(clientVm => clientVm.RegistrationEndDate,
                    opt => opt.MapFrom(client => client.RegistrationEndDate))
                .ForMember(clientVm => clientVm.Status,
                    opt => opt.MapFrom(client => client.Status));
        }
    }
}
