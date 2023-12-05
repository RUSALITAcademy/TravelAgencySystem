using Backend.Application.Interfaces;
using Backend.Application.Models.Passport.Commands.CreatePassport;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.InternationalPassport.Commands.CreateInternationalPassport
{
    public class CreateInternationalPassportCommandHandler : IRequestHandler<CreateInternationalPassportCommand, Guid>
    {

        private readonly IInternationalPassportDbContext _dbContext;

        public CreateInternationalPassportCommandHandler(IInternationalPassportDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateInternationalPassportCommand request,
            CancellationToken cancellationToken)
        {
            var passport = new Domain.Models.InternationalPassport
            {
                InternationalPassportId = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Patronymic = request.Patronymic,
                Number = request.Number,
                Series = request.Series,
                UserId = request.UserId
            };
            await _dbContext.InternationalPassport.AddAsync(passport, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return passport.InternationalPassportId;
        }
    }
}
