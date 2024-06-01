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
                createClientCommand.UserName).NotEmpty().MaximumLength(30);
            RuleFor(createClientCommand =>
                createClientCommand.FirstName).MaximumLength(30);
            RuleFor(createClientCommand =>
                createClientCommand.LastName).MaximumLength(30);
            RuleFor(createClientCommand =>
                createClientCommand.Patronymic).MaximumLength(30);
            RuleFor(createClientCommand =>
                createClientCommand.Password).NotEmpty().MinimumLength(3).MaximumLength(15);
            RuleFor(createClientCommand =>
                createClientCommand.Email).NotEmpty().MaximumLength(50);
        }
    }
}