using Backend.Application.Models.Users.Commands.DeleteUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Tours.Commands.DeleteTour
{
    public class DeleteTourCommandValidator 
        : AbstractValidator<DeleteTourCommand>
    {
        public DeleteTourCommandValidator()
        {
            RuleFor(deleteTourCommand => deleteTourCommand.TourId).NotEqual(Guid.Empty);
        }
    }
}
