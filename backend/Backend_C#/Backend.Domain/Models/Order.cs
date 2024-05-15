using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public User User { get; set; } 
        public string UserId { get; set; }
        public Tour Tour { get; set; }
        public Guid TourId { get; set; }
        public DateTime RegistrationStartDate { get; set; }
        public DateTime RegistrationEndDate { get; set; }
        public string NumberPhone { get; set; }
        public OrderStatus Status { get; set; }
        public bool HasChildren { get; set; }
        public int NumberOfPeople { get; set; }

    }
}
