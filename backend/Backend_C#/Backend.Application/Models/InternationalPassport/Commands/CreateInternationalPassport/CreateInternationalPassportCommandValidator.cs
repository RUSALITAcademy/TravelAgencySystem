using Backend.Application.Models.Passport.Commands.CreatePassport;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.InternationalPassport.Commands.CreateInternationalPassport
{
    public class CreateInternationalPassportCommandValidator : AbstractValidator<CreateInternationalPassportCommand>
    {
        public CreateInternationalPassportCommandValidator()
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
