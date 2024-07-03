using Backend.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Tours.Queries.GetTourList
{
    public class GetTourListQuery : IRequest<TourListVm>
    {
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public string? UserId { get; set; }

        public TourStatus? TourStatus { get; set; }
    }
}
