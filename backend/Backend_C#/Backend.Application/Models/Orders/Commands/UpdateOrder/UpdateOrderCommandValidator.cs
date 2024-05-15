using Backend.Application.Models.Users.Commands.UpdateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(updateClientCommand => updateClientCommand.OrderId).NotEqual(Guid.Empty);
            RuleFor(createClientCommand => createClientCommand.RegistrationStartDate).NotEmpty();
            RuleFor(createClientCommand => createClientCommand.RegistrationEndDate).NotEmpty();
            RuleFor(createClientCommand => createClientCommand.Status).NotEmpty();
        }
    }
}
