using Backend.Application.Common.Exceptions;
using Backend.Application.Interfaces;
using Backend.Application.Models.Users.Commands.UpdateUser;
using Backend.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Tours.Commands.UpdateTour
{
    public class UpdateTourCommandHandler :
        IRequestHandler<UpdateTourCommand>
    {
        private readonly ITourDbContext _dbContext;
        public UpdateTourCommandHandler(ITourDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateTourCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Tour.FirstOrDefaultAsync(tour =>
                tour.TourId == request.TourId, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Tour), request.TourId);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Country = request.Country;
            entity.Region = request.Region;
            entity.StartDate = request.StartDate;
            entity.EndDate = request.EndDate;
            entity.Price = request.Price;
            entity.Quantity = request.Quantity;
            entity.ImgUrl = request.ImgUrl;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
