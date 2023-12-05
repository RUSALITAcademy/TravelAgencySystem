using Backend.Application.Common.Exceptions;
using Backend.Application.Interfaces;
using Backend.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Models.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler :
        IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserDbContext _dbContext;
        public UpdateUserCommandHandler(IUserDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateUserCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.User.FirstOrDefaultAsync(client =>
                client.UserId == request.UserId, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }

            entity.Name = request.Name;
            entity.Password = request.Password;
            entity.Email = request.Email;
            entity.ImgUrl = request.ImgUrl;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
