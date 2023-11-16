using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Interfaces;
using Backend.Application.Models.Users.Queries.GetUserDetails;
using Backend.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Models.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler
    : IRequestHandler<GetOrderDetailsQuery, OrderDetailsVm>
    {
        private readonly IOrderDbContext _dbContext;
        private readonly IMapper _mapper;

        public async Task<OrderDetailsVm> Handle(GetOrderDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Order
                .FirstOrDefaultAsync(client =>
                client.OrderId == request.OrderId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Order), request.OrderId);
            }

            return _mapper.Map<OrderDetailsVm>(entity);
        }
    }
}
