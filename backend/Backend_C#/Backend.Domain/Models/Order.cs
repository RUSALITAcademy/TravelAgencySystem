using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public User User { get; set; } 
        public Guid UserId { get; set; }
        public Tour Tour { get; set; }
        public Guid TourId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; }
    }
}
