using Backend.Application.Common.Exceptions;
using Backend.Application.Interfaces;
using Backend.Application.Models.Users.Commands.DeleteUser;
using Backend.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderDbContext _dbContext;
        public DeleteOrderCommandHandler(IOrderDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task Handle(DeleteOrderCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Order.FindAsync(new object[] { request.OrderId }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.OrderId);
            }

            _dbContext.Order.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

        }
    }
}
