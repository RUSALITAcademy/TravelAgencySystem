using MediatR;

namespace Backend.Application.Models.Users.Commands.CreateUser
{
    public class CreateUserCommand :
        IRequest<Guid>
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ImgUrl { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }

    }
}
