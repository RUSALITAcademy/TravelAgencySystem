using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Tours.Commands.UpdateTour
{
    public class UpdateTourCommand
    : IRequest
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
    }
}
