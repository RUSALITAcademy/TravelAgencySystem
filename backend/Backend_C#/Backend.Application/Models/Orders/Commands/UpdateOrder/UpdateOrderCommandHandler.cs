using Backend.Application.Common.Exceptions;
using Backend.Application.Interfaces;
using Backend.Application.Models.Orders.Commands.UpdateOrder;
using Backend.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler :
        IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderDbContext _dbContext;
        public UpdateOrderCommandHandler(IOrderDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateOrderCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Order.FirstOrDefaultAsync(client =>
                client.OrderId == request.OrderId, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Order), request.OrderId);
            }

            //entity.User = request.User;
            //entity.Tour = request.Tour;
            entity.RegistrationDate = request.RegistrationDate;
            entity.Status = request.Status;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
