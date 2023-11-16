using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.Passport.Commands.UpdatePassport
{
    public class UpdatePassportCommand : IRequest
    {
        public Guid PassportId { get; set; }
        public int Series { get; set; }
        public int Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        //public DateTime Birthday { get; set; }
        //public DateTime Issued { get; set; }
    }
}
