using Backend.Application.Common.Exceptions;
using Backend.Application.Interfaces;
using Backend.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Models.Passport.Commands.UpdatePassport
{
    public class UpdatePassportCommandHandler : IRequestHandler<UpdatePassportCommand>
    {
        private readonly IPassportDbContext _dbContext;
        public UpdatePassportCommandHandler(IPassportDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdatePassportCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Passport.FirstOrDefaultAsync(client =>
                client.PassportId == request.PassportId, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Order), request.PassportId);
            }

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Patronymic = request.Patronymic;
            entity.Series = request.Series;
            entity.Number = request.Number;
            //Birthday
            //Issued

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
