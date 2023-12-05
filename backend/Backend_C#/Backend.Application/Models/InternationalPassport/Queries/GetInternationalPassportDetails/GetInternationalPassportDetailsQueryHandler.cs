using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Interfaces;
using Backend.Application.Models.Passport.Queries.GetPassportDetails;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.InternationalPassport.Queries.GetInternationalPassportDetails
{
    public class GetInternationalPassportDetailsQueryHandler : IRequestHandler<GetInternationalPassportDetailsQuery, InternationalPassportDetailsVm>
    {
        private readonly IInternationalPassportDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetInternationalPassportDetailsQueryHandler(IInternationalPassportDbContext dbContext,
                IMapper mapper) =>
                (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<InternationalPassportDetailsVm> Handle(GetInternationalPassportDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.InternationalPassport
                .FirstOrDefaultAsync(client =>
                client.InternationalPassportId == request.InternationalPassportId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Passport), request.InternationalPassportId);
            }

            return _mapper.Map<InternationalPassportDetailsVm>(entity);
        }
    }
}
