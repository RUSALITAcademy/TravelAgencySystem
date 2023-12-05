using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Domain.Models;

namespace Backend.Application.Models.Tours.Queries.GetTourList
{
    public class TourLookupDto : IMapWith<Tour>
    {
        public Guid TourId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string? Region { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Quantity { get; set; }
        public string ImgUrl { get; set; }
        public double Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tour, TourLookupDto>()
                .ForMember(tourVm => tourVm.Name,
                    opt => opt.MapFrom(tour => tour.Name))
                .ForMember(tourVm => tourVm.Description,
                    opt => opt.MapFrom(tour => tour.Description))
                .ForMember(tourVm => tourVm.Country,
                    opt => opt.MapFrom(tour => tour.Country))
                .ForMember(tourVm => tourVm.Region,
                    opt => opt.MapFrom(tour => tour.Region))
                .ForMember(tourVm => tourVm.StartDate,
                    opt => opt.MapFrom(tour => tour.StartDate))
                .ForMember(tourVm => tourVm.EndDate,
                    opt => opt.MapFrom(tour => tour.EndDate))
                .ForMember(tourVm => tourVm.Price,
                    opt => opt.MapFrom(tour => tour.Price))
                .ForMember(clientVm => clientVm.Quantity,
                    opt => opt.MapFrom(client => client.Quantity))
                .ForMember(clientVm => clientVm.ImgUrl,
                    opt => opt.MapFrom(client => client.ImgUrl));
        }
    }
}
