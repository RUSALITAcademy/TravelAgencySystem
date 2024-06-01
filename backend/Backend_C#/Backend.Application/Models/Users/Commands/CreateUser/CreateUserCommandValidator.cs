using FluentValidation;

namespace Backend.Application.Models.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator() 
        {
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
