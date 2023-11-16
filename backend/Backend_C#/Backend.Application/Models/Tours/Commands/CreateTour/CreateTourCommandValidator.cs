using Backend.Application.Models.Users.Commands.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Tours.Commands.CreateTour
{
    public class CreateTourCommandValidator : AbstractValidator<CreateTourCommand>
    {
        public CreateTourCommandValidator()
        {
            RuleFor(createTourCommand =>
                createTourCommand.Name).NotEmpty().MaximumLength(35);
            RuleFor(createTourCommand =>
                createTourCommand.Description).NotEmpty().MaximumLength(255);
            RuleFor(createTourCommand =>
                createTourCommand.Country).NotEmpty().MaximumLength(25);
            RuleFor(createTourCommand =>
                createTourCommand.Region).MaximumLength(25);
            RuleFor(createTourCommand =>
                createTourCommand.StartDate).NotEmpty().GreaterThan(DateTime.Today);
            RuleFor(createTourCommand =>
                createTourCommand.Price).NotEmpty().GreaterThan(0);
            RuleFor(createTourCommand =>
                createTourCommand.Quantity).NotEmpty().GreaterThan(0);
        }
    }
}
