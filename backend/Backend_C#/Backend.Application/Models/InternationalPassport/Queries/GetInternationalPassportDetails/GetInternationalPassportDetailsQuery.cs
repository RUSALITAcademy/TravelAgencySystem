using Backend.Application.Models.Passport.Queries.GetPassportDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.InternationalPassport.Queries.GetInternationalPassportDetails
{
    public class GetInternationalPassportDetailsQuery : IRequest<InternationalPassportDetailsVm>
    {
        public Guid InternationalPassportId { get; set; }

    }
}
