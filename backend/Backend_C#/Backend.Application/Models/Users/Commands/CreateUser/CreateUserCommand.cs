﻿using MediatR;

namespace Backend.Application.Models.Users.Commands.CreateUser
{
    public class CreateUserCommand :
        IRequest<Guid>
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
