using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Models
{
    public class InternationalPassport
    {
        public Guid InternationalPassportId { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        //public DateTime Issued { get; set; }
        //public DateTime ValidUntil { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
