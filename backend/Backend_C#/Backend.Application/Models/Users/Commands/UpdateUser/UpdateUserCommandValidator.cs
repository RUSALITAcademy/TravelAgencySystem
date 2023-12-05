using FluentValidation;

namespace Backend.Application.Models.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator
        : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(updateClientCommand =>
                updateClientCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(createClientCommand =>
                createClientCommand.Name).NotEmpty().MaximumLength(20);
            RuleFor(createClientCommand =>
                createClientCommand.Password).NotEmpty().MinimumLength(3).MaximumLength(15);
            RuleFor(createClientCommand =>
                createClientCommand.Email).NotEmpty().MaximumLength(50);
        }
    }
}