using Backend.Application.Interfaces;
using MediatR;
using Backend.Domain.Models;

namespace Backend.Application.Models.Passport.Commands.CreatePassport
{
    internal class CreatePassportCommandHandler : IRequestHandler<CreatePassportCommand, Guid>
    {

        private readonly IPassportDbContext _dbContext;

        public CreatePassportCommandHandler(IPassportDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreatePassportCommand request,
            CancellationToken cancellationToken)
        {
            var passport = new Domain.Models.Passport
            {
                PassportId = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Patronymic = request.Patronymic,
                Number = request.Number,
                Series = request.Series,
                UserId = request.UserId
            };
            await _dbContext.Passport.AddAsync(passport, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return passport.PassportId;
        }
    }
}
