using Backend.Application.Interfaces;
using Backend.Domain.Models;
using MediatR;


namespace Backend.Application.Models.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler 
        : IRequestHandler<CreateUserCommand, Guid>
    {

        private readonly IUserDbContext _dbContext;

        public CreateUserCommandHandler(IUserDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var user = new User
            {
                UserId = Guid.NewGuid(),
                Email = request.Email,
                Password = request.Password,
                Name = request.Name,
                ImgUrl = request.ImgUrl
            };
            await _dbContext.User.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return user.UserId;
        }
    }
}
