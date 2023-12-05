using Backend.Application.Models.Users.Commands.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(createClientCommand =>
                createClientCommand.UserId).NotEmpty();
            RuleFor(createClientCommand =>
                createClientCommand.TourId).NotEmpty();
            //RuleFor(createClientCommand =>
            //    createClientCommand.Tour).NotEmpty();
            RuleFor(createClientCommand =>
                createClientCommand.RegistrationDate).NotEmpty().GreaterThanOrEqualTo(DateTime.Today);
            RuleFor(createClientCommand =>
                createClientCommand.Status).NotEmpty();
        }
    }
}
