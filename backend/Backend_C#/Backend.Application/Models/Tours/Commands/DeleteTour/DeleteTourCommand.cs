using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Tours.Commands.DeleteTour
{
    public class DeleteTourCommand : IRequest
    {
        public Guid TourId { get; set; }
    }
}
