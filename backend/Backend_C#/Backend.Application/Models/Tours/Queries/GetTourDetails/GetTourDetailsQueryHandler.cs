using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Interfaces;
using Backend.Application.Models.Users.Queries.GetUserDetails;
using Backend.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Tours.Queries.GetTourDetails
{
    public class GetTourDetailsQueryHandler
    : IRequestHandler<GetTourDetailsQuery, TourDetailsVm>
    {
        private readonly ITourDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTourDetailsQueryHandler(ITourDbContext dbContext,
                IMapper mapper) =>
                (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<TourDetailsVm> Handle(GetTourDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Tour
                .FirstOrDefaultAsync(client =>
                client.TourId == request.TourId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Tour), request.TourId);
            }

            return _mapper.Map<TourDetailsVm>(entity);
        }
    }
}
