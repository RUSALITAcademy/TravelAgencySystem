using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Models.Tours.Commands.CreateTour;
using Backend.Domain.Models;

namespace Backend.WebAPI.Models.CreateDto
{
    public class CreateTourDto
    : IMapWith<CreateTourCommand>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string? Region { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Quantity { get; set; }
        //public string ImgUrl { get; set; }
        //public List<TourImage> Images { get; set; }
        public double Price { get; set; }
        public TourStatus Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTourDto, CreateTourCommand>()
                .ForMember(clientVm => clientVm.Name,
                    opt => opt.MapFrom(client => client.Name))
                .ForMember(clientVm => clientVm.Description,
                    opt => opt.MapFrom(client => client.Description))
                .ForMember(clientVm => clientVm.Country,
                    opt => opt.MapFrom(client => client.Country))
                .ForMember(clientVm => clientVm.Region,
                    opt => opt.MapFrom(client => client.Region))
                .ForMember(clientVm => clientVm.StartDate,
                    opt => opt.MapFrom(client => client.StartDate))
                .ForMember(clientVm => clientVm.EndDate,
                    opt => opt.MapFrom(client => client.EndDate))
                .ForMember(clientVm => clientVm.Price,
                    opt => opt.MapFrom(client => client.Price))
                .ForMember(clientVm => clientVm.Quantity,
                    opt => opt.MapFrom(client => client.Quantity))
                .ForMember(clientVm => clientVm.Status,
                    opt => opt.MapFrom(client => client.Status));
            /*.ForMember(clientVm => clientVm.Images,
                opt => opt.MapFrom(client => client.Images));*/
        }
    }
}
