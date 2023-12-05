using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Models.Orders.Commands.CreateOrder;
using Backend.Domain.Models;

namespace Backend.WebAPI.Models.CreateDto
{
    public class CreateOrderDto
        : IMapWith<CreateOrderCommand>
    {
        public Guid UserId { get; set; }
        public Guid TourId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderDto, CreateOrderCommand>()
                .ForMember(clientVm => clientVm.UserId,
                    opt => opt.MapFrom(client => client.UserId))
                .ForMember(clientVm => clientVm.TourId,
                    opt => opt.MapFrom(client => client.TourId))
                .ForMember(clientVm => clientVm.RegistrationDate,
                    opt => opt.MapFrom(client => client.RegistrationDate))
                .ForMember(clientVm => clientVm.Status,
                    opt => opt.MapFrom(client => client.Status));
        }
    }
}
