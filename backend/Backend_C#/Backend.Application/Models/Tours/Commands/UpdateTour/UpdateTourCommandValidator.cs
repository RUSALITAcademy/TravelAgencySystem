using Backend.Application.Models.Users.Commands.UpdateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Tours.Commands.UpdateTour
{
    public class UpdateTourCommandValidator
    : AbstractValidator<UpdateTourCommand>
    {
        public UpdateTourCommandValidator()
        {
            RuleFor(updateTourCommand =>
                updateTourCommand.TourId).NotEqual(Guid.Empty);
            RuleFor(createTourCommand =>
                createTourCommand.Name).NotEmpty().MaximumLength(60);
            RuleFor(createTourCommand =>
                createTourCommand.Description).NotEmpty().MaximumLength(3200);
            RuleFor(createTourCommand =>
                createTourCommand.Country).NotEmpty().MaximumLength(25);
            RuleFor(createTourCommand =>
                createTourCommand.Region).MaximumLength(60);
            RuleFor(createTourCommand =>
                createTourCommand.StartDate).NotEmpty();
            RuleFor(createTourCommand =>
                createTourCommand.Price).NotEmpty().GreaterThan(0);
        }
    }
}
