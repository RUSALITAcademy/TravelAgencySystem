using Backend.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.InternationalPassport.Commands.CreateInternationalPassport
{
    public class CreateInternationalPassportCommand : IRequest<Guid>
    {
        public int Series { get; set; }
        public int Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        //public DateTime Issued { get; set; }
        //public DateTime ValidUntil { get; set; }
        public Guid UserId { get; set; }
    }
}
