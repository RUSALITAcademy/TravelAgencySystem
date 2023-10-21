using AutoMapper;
using Backend.Application.Common.Exceptions;
using Backend.Application.Interfaces;
using Backend.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Models.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler 
        : IRequestHandler<GetUserDetailsQuery, UserDetailsVm>
    {
        private readonly IUserDbContext _dbContext;
        private readonly IMapper _mapper;

        public async Task<UserDetailsVm> Handle(GetUserDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.User
                .FirstOrDefaultAsync(client =>
                client.UserId == request.UserId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }

            return _mapper.Map<UserDetailsVm>(entity);
        }
    }
}
