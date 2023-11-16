﻿using Backend.Application.Common.Exceptions;
using Backend.Application.Interfaces;
using Backend.Application.Models.Users.Commands.DeleteUser;
using Backend.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Tours.Commands.DeleteTour
{
    public class DeleteTourCommandHandler : IRequestHandler<DeleteTourCommand>
    {
        private readonly ITourDbContext _dbContext;
        public DeleteTourCommandHandler(ITourDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task Handle(DeleteTourCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Tour.FindAsync(new object[] { request.TourId }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Tour), request.TourId);
            }

            _dbContext.Tour.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

        }
    }
}
