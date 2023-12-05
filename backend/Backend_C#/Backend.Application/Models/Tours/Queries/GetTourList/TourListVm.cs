using Backend.Application.Models.Users.Queries.GetUserList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Tours.Queries.GetTourList
{
    public class TourListVm
    {
        public IList<TourLookupDto>? Tours { get; set; }
    }
}
