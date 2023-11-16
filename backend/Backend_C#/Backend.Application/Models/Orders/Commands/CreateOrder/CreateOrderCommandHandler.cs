using Backend.Application.Interfaces;
using Backend.Application.Models.Users.Commands.CreateUser;
using Backend.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler
        : IRequestHandler<CreateOrderCommand, Guid>
    {

        private readonly IOrderDbContext _dbContext;

        public CreateOrderCommandHandler(IOrderDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateOrderCommand request,
            CancellationToken cancellationToken)
        {
            var order = new Order
            {
                OrderId = Guid.NewGuid(),
                RegistrationDate = request.RegistrationDate,
                Status = request.Status,
                TourId = request.TourId,
                UserId = request.UserId
            };
            await _dbContext.Order.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.OrderId;
        }
    }
}
