using Backend.Application.Common.Exceptions;
using Backend.Application.Interfaces;
using Backend.Application.Models.Passport.Commands.UpdatePassport;
using Backend.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.InternationalPassport.Commands.UpdateInternationalPassport
{
    public class UpdateInternationalPassportCommandHandler : IRequestHandler<UpdateInternationalPassportCommand>
    {
        private readonly IInternationalPassportDbContext _dbContext;
        public UpdateInternationalPassportCommandHandler(IInternationalPassportDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateInternationalPassportCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.InternationalPassport.FirstOrDefaultAsync(client =>
                client.InternationalPassportId == request.InternationalPassportId, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Order), request.InternationalPassportId);
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
