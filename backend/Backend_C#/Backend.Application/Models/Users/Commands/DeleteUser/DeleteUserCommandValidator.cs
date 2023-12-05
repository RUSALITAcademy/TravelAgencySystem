using FluentValidation;

namespace Backend.Application.Models.Users.Commands.DeleteUser
{
    public class DeleteUserCommandValidator 
        : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator() 
        {
            RuleFor(deleteUserCommand => deleteUserCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
