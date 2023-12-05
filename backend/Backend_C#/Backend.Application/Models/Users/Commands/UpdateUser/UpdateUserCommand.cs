using MediatR;

namespace Backend.Application.Models.Users.Commands.UpdateUser
{
    public class UpdateUserCommand 
        : IRequest 
    {
        public Guid UserId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string ImgUrl { get; set; }
    }
}
