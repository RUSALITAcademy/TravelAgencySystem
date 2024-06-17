using MediatR;

namespace Backend.Application.Models.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public string UserId { get; set; }
    }
}
