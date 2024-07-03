using Backend.Domain.Models;
using MediatR;

namespace Backend.Application.Models.Tours.Commands.CreateTour
{
    public class CreateTourCommand
        : IRequest<Guid>
    {
        public string UserId { get; set; }
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
    }
}
