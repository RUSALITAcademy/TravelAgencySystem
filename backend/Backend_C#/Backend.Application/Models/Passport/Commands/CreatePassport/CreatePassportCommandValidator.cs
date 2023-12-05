using Backend.Application.Models.Orders.Commands.CreateOrder;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Passport.Commands.CreatePassport
{
    public class CreatePassportCommandValidator : AbstractValidator<CreatePassportCommand>
    {
        public CreatePassportCommandValidator()
        {
            RuleFor(createClientCommand =>
                createClientCommand.Number).NotEmpty();
            RuleFor(createClientCommand =>
                createClientCommand.Series).NotEmpty();
            RuleFor(createClientCommand =>
                createClientCommand.FirstName).NotEmpty();
            RuleFor(createClientCommand =>
                createClientCommand.LastName).NotEmpty();
            RuleFor(createClientCommand =>
                createClientCommand.Patronymic).NotEmpty();
            RuleFor(createFeedbackCommand =>
                createFeedbackCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
