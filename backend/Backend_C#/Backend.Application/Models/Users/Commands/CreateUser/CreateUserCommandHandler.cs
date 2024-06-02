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
                Id = Guid.NewGuid().ToString(),
                Email = request.Email,
                //Password = request.Password,
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                ImgUrl = request.ImgUrl
            };
            await _dbContext.User.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Guid.Parse(user.Id);
        }
    }
}
