using Backend.Application.Models.Users.Queries.GetUserDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Tours.Queries.GetTourDetails
{
    public class GetTourDetailsQuery
     : IRequest<TourDetailsVm>
    {
        public Guid TourId { get; set; }

    }
}
