using Backend.Application.Common.Exceptions;
using Backend.Application.Interfaces;
using Backend.Domain.Models;
using MediatR;

namespace Backend.Application.Models.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserDbContext _dbContext;
        public DeleteUserCommandHandler(IUserDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task Handle(DeleteUserCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.User.FindAsync(new object[] { request.UserId }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }

            _dbContext.User.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

        }
    }
}
