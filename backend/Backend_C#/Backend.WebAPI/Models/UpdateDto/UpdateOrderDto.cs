using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Models.Orders.Commands.UpdateOrder;
using Backend.Domain.Models;

namespace Backend.WebAPI.Models.UpdateDto
{
    public class UpdateOrderDto
    : IMapWith<UpdateOrderCommand>
    {
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateOrderDto, UpdateOrderCommand>()
                .ForMember(clientVm => clientVm.RegistrationDate,
                    opt => opt.MapFrom(client => client.RegistrationDate))
                .ForMember(clientVm => clientVm.Status,
                    opt => opt.MapFrom(client => client.Status));
        }
    }
}
