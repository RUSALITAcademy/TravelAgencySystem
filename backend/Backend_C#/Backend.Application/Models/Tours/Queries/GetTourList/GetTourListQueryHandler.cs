using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Tours.Queries.GetTourList
{
    public class GetTourListQueryHandler : IRequestHandler<GetTourListQuery, TourListVm>
    {
        private readonly ITourDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTourListQueryHandler(ITourDbContext dbContext,
                IMapper mapper) =>
                (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<TourListVm> Handle(GetTourListQuery request, CancellationToken cancelToken)
        {
            var query = _dbContext.Tour.AsQueryable();

            if (request.MinPrice.HasValue)
            {
                query = query.Where(t => t.Price >= request.MinPrice.Value);
            }

            if (request.MaxPrice.HasValue)
            {
                query = query.Where(t => t.Price <= request.MaxPrice.Value);
            }

            var tourQuery = await query
                .ProjectTo<TourLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancelToken);

            return new TourListVm { Tours = tourQuery };
        }
    }
}
