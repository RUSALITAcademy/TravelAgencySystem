using MediatR;

namespace Backend.Application.Models.Users.Commands.UpdateUser
{
    public class UpdateUserCommand 
        : IRequest 
    {
        public string? UserName { get; set; }
        public string UserId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? ImgUrl { get; set; }
    }
}
