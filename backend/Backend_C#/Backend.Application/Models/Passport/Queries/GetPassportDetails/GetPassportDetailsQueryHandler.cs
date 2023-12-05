using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Models.Passport.Queries.GetPassportDetails
{
    public class GetPassportDetailsQueryHandler : IRequestHandler<GetPassportDetailsQuery, PassportDetailsVm>
    {
        private readonly IPassportDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPassportDetailsQueryHandler(IPassportDbContext dbContext,
                IMapper mapper) =>
                (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<PassportDetailsVm> Handle(GetPassportDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Passport
                .FirstOrDefaultAsync(client =>
                client.PassportId == request.PassportId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Passport), request.PassportId);
            }

            return _mapper.Map<PassportDetailsVm>(entity);
        }
    }
}
