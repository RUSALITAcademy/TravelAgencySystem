using Backend.Application.Interfaces;
using Backend.Domain.Models;
using MediatR;

namespace Backend.Application.Models.Tours.Commands.CreateTour
{
    public class CreateTourCommandHandler
        : IRequestHandler<CreateTourCommand, Guid>
    {

        private readonly ITourDbContext _dbContext;

        public CreateTourCommandHandler(ITourDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateTourCommand request,
            CancellationToken cancellationToken)
        {
            var tour = new Tour
            {
                TourId = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Country = request.Country,
                Region = request.Region,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Price = request.Price,
                Quantity = request.Quantity,
                ImgUrl = request.ImgUrl
            };
            await _dbContext.Tour.AddAsync(tour, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return tour.TourId;
        }
    }
}
