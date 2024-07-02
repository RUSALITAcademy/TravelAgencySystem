using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend.Application.Interfaces;
using Backend.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Models.Orders.Queries.GetOrderList
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, OrderListVm>
    {
        private readonly IOrderDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IOrderDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<OrderListVm> Handle(GetOrderListQuery request, CancellationToken cancelToken)
        {
            IQueryable<Order> query = _dbContext.Order;

            if (request.IsTourAgent)
            {
                var agentTours = _dbContext.Tour
                    .Where(t => t.UserId == request.UserId)
                    .Select(t => t.TourId);

                query = query.Where(order => agentTours.Contains(order.TourId));
            }
            else
            {
                if (request.UserId != null)
                {
                    query = query.Where(order => order.UserId == request.UserId);
                }

                if (request.TourId.HasValue)
                {
                    query = query.Where(order => order.TourId == request.TourId.Value);
                }
            }

            var orderList = await query
                .ProjectTo<OrderLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancelToken);

            return new OrderListVm { Orders = orderList };
        }
    }
}
