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
    }
}
