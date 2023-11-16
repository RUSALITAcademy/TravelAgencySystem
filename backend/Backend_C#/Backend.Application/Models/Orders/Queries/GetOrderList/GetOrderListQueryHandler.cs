using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Models.Orders.Queries.GetOrderList
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, OrderListVm>
    {
        private readonly IOrderDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IOrderDbContext dbContext,
                IMapper mapper) =>
                (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<OrderListVm> Handle(GetOrderListQuery request,
            CancellationToken cancelToken)
        {
            var orderQuery = await _dbContext.Order
                .Where(openRecord => openRecord.UserId == request.UserId)
                .ProjectTo<OrderLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancelToken);

            return new OrderListVm { Orders = orderQuery };
        }
    }
}
