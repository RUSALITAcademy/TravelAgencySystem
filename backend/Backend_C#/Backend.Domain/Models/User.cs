using Microsoft.AspNetCore.Identity;

namespace Backend.Domain.Models
{
    public class User: IdentityUser
    {
        public string? ImgUrl { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }

        public List<Order>? Orders { get; set; } // Связь с Order, один ко многим
    }
}
