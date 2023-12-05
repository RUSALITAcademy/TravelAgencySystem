using FluentValidation;

namespace Backend.Application.Models.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator() 
        {
            RuleFor(createClientCommand =>
                createClientCommand.Name).NotEmpty().MaximumLength(20);
            RuleFor(createClientCommand =>
                createClientCommand.Password).NotEmpty().MinimumLength(3).MaximumLength(15);
            RuleFor(createClientCommand =>
                createClientCommand.Email).NotEmpty().MaximumLength(50);
        }
    }
}
