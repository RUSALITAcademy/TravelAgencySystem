using Backend.Application.Models.Orders.Commands.UpdateOrder;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Passport.Commands.UpdatePassport
{
    public class UpdatePassportCommandValidator : AbstractValidator<UpdatePassportCommand>
    {
        public UpdatePassportCommandValidator()
        {
            RuleFor(updateClientCommand =>
                updateClientCommand.PassportId).NotEqual(Guid.Empty);
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
        }
    }
}
