using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Models.Orders.Commands.CreateOrder;
using Backend.Application.Models.Tours.Queries.GetTourList;
using Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Orders.Queries.GetOrderList
{
    public class OrderLookupDto : IMapWith<Order>
    {
        public Guid UserId { get; set; }
        public Guid TourId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderLookupDto>()
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
