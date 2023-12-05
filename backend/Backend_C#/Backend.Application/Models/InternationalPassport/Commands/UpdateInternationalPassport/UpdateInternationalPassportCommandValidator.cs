using Backend.Application.Models.Passport.Commands.UpdatePassport;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.InternationalPassport.Commands.UpdateInternationalPassport
{
    public class UpdateInternationalPassportCommandValidator : AbstractValidator<UpdateInternationalPassportCommand>
    {
        public UpdateInternationalPassportCommandValidator()
        {
            RuleFor(updateClientCommand =>
                updateClientCommand.InternationalPassportId).NotEqual(Guid.Empty);
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
