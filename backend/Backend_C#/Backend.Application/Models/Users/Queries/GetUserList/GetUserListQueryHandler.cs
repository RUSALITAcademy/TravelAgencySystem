using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Models.Users.Queries.GetUserList
{
    public class GetUsertListQueryHandler : IRequestHandler<GetUserListQuery, UserListVm>
    {
        private readonly IUserDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUsertListQueryHandler(IUserDbContext dbContext,
                IMapper mapper) =>
                (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UserListVm> Handle(GetUserListQuery request,
            CancellationToken cancelToken)
        {
            var UsersQuery = await _dbContext.User
                .ProjectTo<UserLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancelToken);

            return new UserListVm { Users = UsersQuery };
        }

    }
}
